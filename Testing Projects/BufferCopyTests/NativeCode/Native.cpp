
#include "Native.h"

extern "C" __declspec(dllexport) void __stdcall NativeBlockCopy(unsigned long* Src, unsigned long* Dest, int Count)
{
    int i = 0;
	
	if (Count == 0)
		return;


	for (; i< (Count % 2); i++)
		*Dest++ = *Src++;
		

	for (; i<Count; i+=2)
	{
		*Dest++ = *Src++;
		*Dest++ = *Src++;
	}

}