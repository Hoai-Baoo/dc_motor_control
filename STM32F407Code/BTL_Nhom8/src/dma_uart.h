#ifndef __DMA_UART_H
#define __DMA_UART_H

#include "stm32f4xx.h"                  // Device header

#define RX_BUFF_SIZE 24
#define TX_BUFF_SIZE 5

typedef struct{
	float setpoint;
	float kp;
	float ki;
	float kd;
} PID_t;

typedef struct{
	PID_t PID;
	uint8_t freq;
	uint8_t encMode;
} data_t;

typedef union {
	struct{
		uint8_t startStop;
		uint8_t setpoint[5];
		uint8_t kp[5];
		uint8_t ki[5];
		uint8_t kd[5];
		uint8_t freq[2];
		uint8_t encMode;
	} data;
	
	uint8_t rawData[RX_BUFF_SIZE];
} frame_t;

void DMA_UartInit(void);
void DMA1_Stream5_IRQHandler(void);
void DMA_UartSend(uint8_t* data);
uint8_t getStartBit(void);
data_t convertData(void);
void DMA_UartSendRpm(int speedSend);

#endif
