#include "Encoder.h"

#include "pwm.h"

#define OUT_DEFINE 12

static double P, I, D;
static double err = 0; 
static double pre_err = 0, pre_pre_err= 0; 
static double out = 0; 
static float f_Kp = 1.0, f_Ki=1.0, f_Kd=0.1, f_setPoint = 0;

double speed = 0;
int32_t counter; 
uint8_t mode;
uint32_t Ts = 5000;	//5ms
uint16_t PrescalerValue = 0;

uint8_t pidFlag = 0;

void resetVariable(void){
	err = 0;
	pre_err = 0;
	pre_pre_err= 0;
	out = 0; 
}

void Encoder_Config(){
		GPIO_InitTypeDef GPIO_InitStructure;	
		RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);

		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_1;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
		GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_Init(GPIOA, &GPIO_InitStructure);
		
		GPIO_PinAFConfig(GPIOA, GPIO_PinSource0, GPIO_AF_TIM2);
		GPIO_PinAFConfig(GPIOA, GPIO_PinSource1, GPIO_AF_TIM2);
		
		if (mode == 1){ //mode x1
				TIM_EncoderInterfaceConfig(TIM2, TIM_EncoderMode_TI1, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising); //resolution 2x
		}
		if (mode == 2){ //mode x2
				TIM_EncoderInterfaceConfig(TIM2, TIM_EncoderMode_TI1, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising); 
		}
		if (mode == 4){ //mode x4
				TIM_EncoderInterfaceConfig(TIM2, TIM_EncoderMode_TI12, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising); 
		}

		TIM_SetAutoreload(TIM2, 0xFFFFFFFF);
		TIM2->CCMR1 |= (10 << 4); //filter
		TIM_Cmd(TIM2, ENABLE);
		TIM2->CNT = 0x00008000;
}

void Timer4_Config(void){
	uint16_t PrescalerValue = (uint16_t) ((SystemCoreClock /2) / 1000000) - 1; // 83
	NVIC_InitTypeDef NVIC_InitStructure;
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);
	 
	TIM_DeInit(TIM4);
	
  TIM_TimeBaseStructure.TIM_Period = Ts-1; //timer_value = ((PrescalerValue+1)*(period+1))/(SystemCoreClock /2)
  TIM_TimeBaseStructure.TIM_Prescaler = PrescalerValue; 
  TIM_TimeBaseStructure.TIM_ClockDivision = 0x0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

  TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);
	
	TIM_ClearITPendingBit(TIM4, TIM_IT_Update);
	
	TIM_ClearFlag(TIM4,TIM_FLAG_Update);
	
	TIM_ITConfig(TIM4,TIM_IT_Update, ENABLE);
	TIM_Cmd (TIM4, ENABLE);
	
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2);
	
	NVIC_InitStructure.NVIC_IRQChannel = TIM4_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	
	NVIC_Init(&NVIC_InitStructure);
}

void  TIM4_IRQHandler(void){
		if (TIM_GetITStatus(TIM4, TIM_IT_Update)==SET)
		{
				TIM_ClearITPendingBit(TIM4, TIM_IT_Update);
				counter = TIM2->CNT - 0x00008000;
			
				if(mode == 1){
					counter = counter/2;
				}
				
				speed = ((double)counter/((double)mode*11.0*45.0))/((double)Ts/1000000);//rps
				TIM2->CNT  = 0x00008000;
			
			pidFlag = 1;
		}
}

void PID(void){
	float duty = 0;
	err = f_setPoint/60 - speed; 
	P = 1.0*(double)f_Kp*(err - pre_err);
	I = 0.5*(Ts/(double)1000000)*f_Ki*(err + pre_err);
	D = 1.0*(double)f_Kd/(Ts/(double)1000000)*(err - 2*pre_err + pre_pre_err);
	out = out + P + I + D;
	pre_pre_err = pre_err;
	pre_err = err;
	
	if (out > OUT_DEFINE)	
		out = OUT_DEFINE;
	else if (out < -OUT_DEFINE)		
		out = -OUT_DEFINE;

		duty = out /12 * 100;
	
	if(duty < 0){
		duty = -duty;
			PWM_set_pulse_length_right(duty);
			PWM_set_pulse_length_left(0);
	}
	else{
			PWM_set_pulse_length_right(0);
			PWM_set_pulse_length_left(duty);
	}
}

void encoderConfig(PID_t PID, uint8_t encMode){
	mode = encMode;
	f_Kp = PID.kp;
	f_Ki = PID.ki;
	f_Kd = PID.kd;
	f_setPoint = PID.setpoint;
	
	Encoder_Config();
	Timer4_Config();
}

double getSpeed(void){
	return speed*60;
}
