/**
  ******************************************************************************
  * @file    pwm.h
  * @author  QH
  * @version V1.0.0
  * @date    25/11/2022
  * @brief   
  ******************************************************************************
  */
	
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __PWM_H
#define __PWM_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_rcc.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_tim.h"

/* Exported types ------------------------------------------------------------*/
/* Exported constants --------------------------------------------------------*/
#define TIMER_FREQUENCY 50000

/* Exported macro ------------------------------------------------------------*/
/* Exported functions --------------------------------------------------------*/

void GPIO_Init_output(void);
void TIMER_Init(uint8_t pwmFreq);
void PWM_Init(void);
void PWM_set_pulse_length_right(float dutyCycle);
void PWM_set_pulse_length_left(float dutyCycle);
void PWM_config(uint8_t pwmFreq);

#ifdef __cplusplus
}
#endif

#endif // !__PWM_H
