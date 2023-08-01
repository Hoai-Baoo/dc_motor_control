#include "dma_uart.h"
#include "Encoder.h"
#include "pwm.h"

extern uint8_t 	rcv_flag;
extern uint8_t pidFlag;

double v2Prev = 0, v2Filt = 0;

void startMotor(void){
	data_t data = convertData();
	
	PWM_config(data.freq);
	PWM_set_pulse_length_right(0);
	PWM_set_pulse_length_left(0);
	encoderConfig(data.PID, data.encMode);
}

void stopMotor(void){
	v2Prev = 0;
	v2Filt = 0;
	
	resetVariable();
	PWM_set_pulse_length_right(0);
	PWM_set_pulse_length_left(0);
	TIM_Cmd(TIM2, DISABLE);
	TIM_Cmd(TIM4, DISABLE);
}

void pidHandle(){
	double v2 = getSpeed();
	PID();
	v2Filt = 0.854*v2Filt + 0.0728*v2 + 0.0728*v2Prev;
	v2Prev = v2;
	DMA_UartSendRpm(v2Filt);
}

int main(void){
		DMA_UartInit();
	

		while(1){
			if(rcv_flag == 1){
				if(getStartBit() == 1){
					startMotor();
				}
				else{
					stopMotor();
				}
				
				rcv_flag = 0;
			}
			
			if(pidFlag == 1){
				pidHandle();
				pidFlag = 0;
			}
		}
}
