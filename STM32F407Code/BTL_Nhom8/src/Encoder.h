#ifndef __ENCODER_CONFIG_H
#define __ENCODER_CONFIG_H

#include "dma_uart.h"

void Encoder_Config(void);
void Timer4_Config(void);
void TIM4_IRQHandler(void);
void PID(void);
void encoderConfig(PID_t PID, uint8_t encMode);
double getSpeed(void);
void GPIO_Config(void);
void resetVariable(void);

#endif
