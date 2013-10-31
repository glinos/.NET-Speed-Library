.NET Speed Library V0.1
Author: Harry Glinos  (harry@glinos-labs.org)
Website: www.glinos-labs.org
 
The goal for this project is to provide a library of common programming tasks to make your .Net 
programs run faster. Each of the methods provided have tweaked for speed runs faster than what is
 provided by the .Net library.

The only method available at the moment is StringReverse. It is the fastest implementation that I 
know. If anyone has a way to do it faster, I love to know. Library is written in C# and unmanaged 
C/C++. Based on tuning that I have done on my home machine, the method will decide to which code 
path will be faster based on the length of the string. Anything less than 93 characters will be run 
in managed code while longer strings will be processed using a native DLL. Making a call into a native 
DLL has some overhead and the efficiencies take over at about 93 characters, which is what I found 
to be the break-even point.

In future versions I will be adding more functions to this library. 


**Files:

dotNetSpeedLib.dll - Create a reference to this dll in your .Net project. 
NativeCode.dll  - Required by dotNetSpeedLib.dll. Include in the same location as your program.


**Things to keep in mind

The optimizations are noticeable when running the release build of your program outside of IDE. 
Running the library in debug mode will usually be slower than using the .Net framework 
provided functions. In other words, don't judge the library based on timings obtained in a debug build. 


**License

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