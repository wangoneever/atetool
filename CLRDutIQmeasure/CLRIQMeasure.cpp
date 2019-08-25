#include "stdafx.h"
#include "CLRIQMeasure.h"
#include "windows.h"
#include "stdio.h"

void OutputDebugPrintf(const char* strOutputString, ...)
{
	char strBuffer[4096] = { 0 };
	va_list vlArgs;
	va_start(vlArgs, strOutputString);
	_vsnprintf(strBuffer, sizeof(strBuffer) - 1, strOutputString, vlArgs);
	//vsprintf(strBuffer,strOutputString,vlArgs);
	va_end(vlArgs);
	OutputDebugStringA(strBuffer);
}
CLRIQMeasure::CLRIQMeasure()
{
}

int CLRIQMeasure::add(int a, int b)
{
	int c;
	c = a + b;

	//char msgbuf[1024];
	//sprintf(msgbuf, "kajsdkfj");
	//OutputDebugStringA(msgbuf);
	
	OutputDebugPrintf("%d,%d", a, b);
	return c;
}

int CLRIQMeasure::showstr(char* ssid)
{
	OutputDebugPrintf("%d,%s",strlen(ssid),ssid);
	return 0;
}

int CLRIQMeasure::feedstr(char* buf)
{
	char videoName[] = "{\"ID\":2,\"Name\":\"ÍõÒ»\",\"Age\":230,\"Sex\":\"ÄÐ\"}";
	strcpy(buf, videoName);
	return 0;
}