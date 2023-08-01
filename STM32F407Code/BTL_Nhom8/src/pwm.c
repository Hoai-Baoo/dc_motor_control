/**
  ******************************************************************************
  * @file    pwm.c
  * @author  QH
  * @version V1.0.0
  * @date    25/11/2022
  * @brief
  ******************************************************************************
  */

  /* Includes ------------------------------------------------------------------*/
#include "pwm.h"

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
static uint16_t TIM_Period = 0;

/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/

/**
  * @brief  This function init gpio ouput of pwm.
  * @param  None
  * @retval None
  */
void GPIO_Init_output(void) {
	GPIO_InitTypeDef GPIO_InitStruct;

	/* Clock for GPIOD */
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);

	/* Alternating functions for pins */
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource6, GPIO_AF_TIM3);
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource7, GPIO_AF_TIM3);

	/* Set pins */
	GPIO_InitStruct.GPIO_Pin = GPIO_Pin_6;
	GPIO_InitStruct.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStruct.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOA, &GPIO_InitStruct);
	
	GPIO_InitStruct.GPIO_Pin = GPIO_Pin_7;
	GPIO_Init(GPIOA, &GPIO_InitStruct);
}

/**
  * @brief  This function init timer.
  * @param  pwmFrequency: select frequency for pwm. 
  * @retval None
  */
void TIMER_Init(uint8_t pwmFreq) {
	TIM_TimeBaseInitTypeDef TIM_BaseStruct;

	/* Enable clock for TIM3 */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
	/*
		TIM5 is connected to APB1 bus, which has on F407 device 42MHz clock
		But, timer has internal PLL, which double this frequency for timer, up to 84MHz
		Remember: Not each timer is connected to APB1, there are also timers connected
		on APB2, which works at 84MHz by default, and internal PLL increase
		this to up to 168MHz

		Set timer prescaller
		Timer count frequency is set with

		timer_tick_frequency = Timer_default_frequency / (prescaller_set + 1)

		In our case, we want a max frequency for timer, so we set prescaller to 0
		And our timer will have tick frequency
	*/
	TIM_BaseStruct.TIM_Prescaler = 0;
	/* Count up */
	TIM_BaseStruct.TIM_CounterMode = TIM_CounterMode_Up;
	/*
		Set timer period when it have reset
		First you have to know max value for timer
		In our case it is 16bit = 65535
		To get your frequency for PWM, equation is simple

		PWM_frequency = timer_tick_frequency / (TIM_Period + 1)

		If you know your PWM frequency you want to have timer period set correct

		TIM_Period = timer_tick_frequency / PWM_frequency - 1

		If you get TIM_Period larger than max timer value (in our case 65535),
		you have to choose larger prescaler and slow down timer tick frequency
	*/
	TIM_Period = (TIMER_FREQUENCY / pwmFreq);

	TIM_BaseStruct.TIM_Period = TIM_Period - 1;
	TIM_BaseStruct.TIM_ClockDivision = TIM_CKD_DIV1;
	TIM_BaseStruct.TIM_RepetitionCounter = 0;
	/* Initialize TIM3 */
	TIM_TimeBaseInit(TIM3, &TIM_BaseStruct);
	/* Start count on TIM3 */
	TIM_Cmd(TIM3, ENABLE);
}

/**
  * @brief  This function init timer.
  * @param  None
  * @retval None
  */
void PWM_Init(void) {
	TIM_OCInitTypeDef TIM_OCStruct;

	TIM_OCStruct.TIM_OCMode = TIM_OCMode_PWM2;
	TIM_OCStruct.TIM_OutputState = TIM_OutputState_Enable;
	TIM_OCStruct.TIM_OCPolarity = TIM_OCPolarity_Low;

	TIM_OCStruct.TIM_Pulse = 0;
	TIM_OC1Init(TIM3, &TIM_OCStruct);
	TIM_OC1PreloadConfig(TIM3, TIM_OCPreload_Enable);
	
	TIM_OC2Init(TIM3, &TIM_OCStruct);
	TIM_OC2PreloadConfig(TIM3, TIM_OCPreload_Enable);
}

/**
  * @brief  This function init timer.
  * @param  dutyCycle: where x can be (0 ... 100) to select output percentage.
  * @retval None
  */
void PWM_set_pulse_length_right(float dutyCycle) {
	/*
		To get proper duty cycle, you have simple equation

		pulse_length = ((TIM_Period + 1) * DutyCycle) / 100 - 1

		where DutyCycle is in percent, between 0 and 100%

		Remember: if pulse_length is larger than TIM_Period, you will have output HIGH all the time
	*/
	uint32_t pulseLength = 0;
	
	if(dutyCycle > 1){
		pulseLength = (uint32_t)(TIM_Period * dutyCycle/100) - 1;
	}

	TIM3->CCR1 = pulseLength;
}

void PWM_set_pulse_length_left(float dutyCycle) {
	/*
		To get proper duty cycle, you have simple equation

		pulse_length = ((TIM_Period + 1) * DutyCycle) / 100 - 1

		where DutyCycle is in percent, between 0 and 100%

		Remember: if pulse_length is larger than TIM_Period, you will have output HIGH all the time
	*/
	uint32_t pulseLength = 0;
	
	if(dutyCycle > 1){
		pulseLength = (uint32_t)(TIM_Period * dutyCycle/100) - 1;
	}
	
	TIM3->CCR2 = pulseLength;
}

void PWM_config(uint8_t pwmFreq){
	GPIO_Init_output();
	TIMER_Init(pwmFreq);
	PWM_Init();
}
