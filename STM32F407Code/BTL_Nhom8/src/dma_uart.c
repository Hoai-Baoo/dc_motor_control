#include "dma_uart.h"
#include "stdio.h"

static uint8_t 	txbuff[TX_BUFF_SIZE];
static uint8_t 	rxbuff[RX_BUFF_SIZE];
uint8_t 	rcv_flag = 0;

static frame_t rawData;

void UART_Config(void){
	GPIO_InitTypeDef 	GPIO_InitStructure; 
	USART_InitTypeDef USART_InitStructure;
	
	  /* Enable GPIO clock */
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
  /* Enable UART clock */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);
	
	/* Connect USART2 pins to AF2 */  
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource2, GPIO_AF_USART2);
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource3, GPIO_AF_USART2); 

  /* GPIO Configuration for USART2 Tx */
  GPIO_InitStructure.GPIO_Pin   = GPIO_Pin_2;
  GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd  = GPIO_PuPd_UP;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  /* GPIO Configuration for USART Rx */
  GPIO_InitStructure.GPIO_Pin   = GPIO_Pin_3;
  GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_AF;
  GPIO_Init(GPIOA, &GPIO_InitStructure);
       
  /* USARTx configured as follow:
		- BaudRate = 115200 baud  
    - Word Length = 8 Bits
    - One Stop Bit
    - No parity
    - Hardware flow control disabled (RTS and CTS signals)
    - Receive and transmit enabled
  */
  USART_InitStructure.USART_BaudRate = 115200;
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;
  USART_InitStructure.USART_StopBits = USART_StopBits_1;
  USART_InitStructure.USART_Parity = USART_Parity_No;
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
  USART_Init(USART2, &USART_InitStructure);

  /* Enable USART2 */
  USART_Cmd(USART2, ENABLE);
}

void DMA_RxConfig(void){
	DMA_InitTypeDef   DMA_InitStructure;
	/* Enable USART2 DMA */
  USART_DMACmd(USART2, USART_DMAReq_Rx, ENABLE);
	/* Enable DMA1 clock */
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_DMA1, ENABLE);
	
	/* DMA1 Stream2 Channel 5 for USART2 Rx configuration */			
  DMA_InitStructure.DMA_Channel = DMA_Channel_4;  
  DMA_InitStructure.DMA_PeripheralBaseAddr = (uint32_t)&USART2->DR;
  DMA_InitStructure.DMA_Memory0BaseAddr = (uint32_t)rxbuff;
  DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralToMemory;
  DMA_InitStructure.DMA_BufferSize = RX_BUFF_SIZE;
  DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;
  DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;
  DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_Byte;
  DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_Byte;
  DMA_InitStructure.DMA_Mode = DMA_Mode_Normal;//DMA_Mode_Circular;
  DMA_InitStructure.DMA_Priority = DMA_Priority_High;
  DMA_InitStructure.DMA_FIFOMode = DMA_FIFOMode_Disable;         
  DMA_InitStructure.DMA_FIFOThreshold = DMA_FIFOThreshold_HalfFull;
  DMA_InitStructure.DMA_MemoryBurst = DMA_MemoryBurst_Single;
  DMA_InitStructure.DMA_PeripheralBurst = DMA_PeripheralBurst_Single;
  DMA_Init(DMA1_Stream5, &DMA_InitStructure);
  DMA_Cmd(DMA1_Stream5, ENABLE);
	
	/* Transfer complete interrupt mask */
  DMA_ITConfig(DMA1_Stream5, DMA_IT_TC, ENABLE);
}

void DMA_TxConfig(){
	DMA_InitTypeDef  	DMA_InitStructure;
		/* Enable USART2 DMA */
  USART_DMACmd(USART2, USART_DMAReq_Tx, ENABLE); 	
	
	/* DMA1 Stream4 Channel 6 for USART2 Tx configuration */			
  DMA_InitStructure.DMA_Channel = DMA_Channel_4;  
  DMA_InitStructure.DMA_PeripheralBaseAddr = (uint32_t)&USART2->DR;
  DMA_InitStructure.DMA_Memory0BaseAddr = (uint32_t)txbuff;
  DMA_InitStructure.DMA_DIR = DMA_DIR_MemoryToPeripheral;
  DMA_InitStructure.DMA_BufferSize = TX_BUFF_SIZE;
  DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;
  DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;
  DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_Byte;
  DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_Byte;
  DMA_InitStructure.DMA_Mode = DMA_Mode_Normal;
  DMA_InitStructure.DMA_Priority = DMA_Priority_High;
  DMA_InitStructure.DMA_FIFOMode = DMA_FIFOMode_Disable;         
  DMA_InitStructure.DMA_FIFOThreshold = DMA_FIFOThreshold_HalfFull;
  DMA_InitStructure.DMA_MemoryBurst = DMA_MemoryBurst_Single;
  DMA_InitStructure.DMA_PeripheralBurst = DMA_PeripheralBurst_Single;
  DMA_Init(DMA1_Stream6, &DMA_InitStructure);
  DMA_Cmd(DMA1_Stream6, ENABLE);
}

void NVIC_Config(){
	NVIC_InitTypeDef  NVIC_InitStructure;	
	
	/* Enable DMA Interrupt to the highest priority */
  NVIC_InitStructure.NVIC_IRQChannel = DMA1_Stream5_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}

void DMA_UartInit(void)
{
  UART_Config();
	DMA_RxConfig();
	DMA_TxConfig();
	NVIC_Config();
}

void DMA1_Stream5_IRQHandler(void)
{
	uint16_t i;

	/* Clear the DMA1_Stream5 TCIF2 pending bit */
	DMA_ClearITPendingBit(DMA1_Stream5, DMA_IT_TCIF5);

	for(i=0; i<RX_BUFF_SIZE; i++)
		rawData.rawData[i] = rxbuff[i];

	rcv_flag = 1;
	
	DMA_Cmd(DMA1_Stream5, ENABLE);
}

void DMA_UartSend(uint8_t* data){
	uint8_t i;
	
	for(i = 0; i < TX_BUFF_SIZE; i++) {
			txbuff[i] = data[i];
	}
	
	DMA_ClearFlag(DMA1_Stream6, DMA_FLAG_TCIF6);
	DMA1_Stream6->NDTR = TX_BUFF_SIZE;
	DMA_Cmd(DMA1_Stream6, ENABLE);
}

float stringToFloat(uint8_t str[]) {
	int i;
	float result;
	char temp[6];
	
	for(i = 0; i < 5; i++) {
		temp[i] = str[i];
	}
	
	temp[5] = '\0';
	sscanf(temp, "%f", &result);

	return result;
}

void DMA_UartSendRpm(int speedSend){
	uint8_t temp[5];
	if(speedSend < 0){
		temp[0] = '-';
		speedSend = -speedSend;
	}
	else{
		temp[0] = '+';
	}
	
	temp[1] = speedSend / 100 + 48;
	speedSend %= 100;
	temp[2] = speedSend / 10 + 48;
	temp[3] = speedSend % 10 + 48;
	temp[4] = '\n';
	
	DMA_UartSend(temp);
}

data_t convertData(void){
	data_t data;
	
	data.PID.kd = stringToFloat(rawData.data.kd);
	data.PID.ki = stringToFloat(rawData.data.ki);
	data.PID.kp = stringToFloat(rawData.data.kp);
	data.PID.setpoint = stringToFloat(rawData.data.setpoint);
	data.freq = (rawData.data.freq[0] - 48)*10 + (rawData.data.freq[1] - 48);
	
	data.encMode = rawData.data.encMode - 48;
	
	return data;
}

uint8_t getStartBit(void){
	return rawData.data.startStop - 48;
}
