/*
Copyright (c) 2013, Harry Glinos
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the <organization> nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL Harry Glinos or Glinos Labs BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/


#include "SpeedLib.h"

    //Reverses a string (char[] array) by reading in 32bits at a time.
	//Pass a pointer to the C# char array and it's size in characters.
	extern "C" __declspec(dllexport) void __stdcall StringReverse(wchar_t* arr, int Size)
	{
		unsigned int Temp;
		unsigned int Temp2;
            
		unsigned int* p;
		unsigned int* q;
		p = (unsigned int*) arr;
		q = (unsigned int*)(arr + Size - 2);
        
		if (Size == 2)
        {
			Temp = *p;
            *p = (Temp >> 16) | (Temp << 16); 
            return;
        }

		while (p < q)
		{
			Temp = *p;
			Temp2 = *q;

			*p = (Temp2 >> 16) | (Temp2 << 16);
			*q = (Temp >> 16) | (Temp << 16); 

			p++;
			q--;
		}
	}

	