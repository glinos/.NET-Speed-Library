using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


using System.Runtime.InteropServices;

namespace BufferCopyTests
{
    public unsafe partial class Form1 : Form
    {
        private const int STEPS = 1000000;
        private const int BLOCK_COPY_SPEED_TUNNING_DOTNET = 125;
        private const int BLOCK_COPY_SPEED_TUNNING_CPP = 250; //not set

        private byte[] bytebuffer1;
        private byte[] bytebuffer5;
        private byte[] bytebuffer20;
        private byte[] bytebuffer50;
        private byte[] bytebuffer100;
        private byte[] bytebuffer200;

        private char[] charbuffer1;
        private char[] charbuffer5;
        private char[] charbuffer20;
        private char[] charbuffer50;
        private char[] charbuffer100;
        private char[] charbuffer200;


        private int[] intbuffer1;
        private int[] intbuffer5;
        private int[] intbuffer20;
        private int[] intbuffer50;
        private int[] intbuffer100;
        private int[] intbuffer200;


        private byte[] bytebufferSpecial;


        private Stopwatch MyTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrepTest();
            RunTestSuite();

        }


        private void PrepTest()
        {

            MyTimer = new Stopwatch();

            bytebuffer1 = new byte[] { 1 };
            bytebuffer5 = new byte[] { 1, 2, 3, 4, 5 };
            bytebuffer20 = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            bytebuffer50 = FillArray(bytebuffer50, 50);
            bytebuffer100 = FillArray(bytebuffer100, 100);
            bytebuffer200 = FillArray(bytebuffer200, 200);

            charbuffer1 = FillArray(charbuffer1, 1);
            charbuffer5 = FillArray(charbuffer5, 5);
            charbuffer20 = FillArray(charbuffer20, 20);
            charbuffer50 = FillArray(charbuffer50, 50);
            charbuffer100 = FillArray(charbuffer100, 100);
            charbuffer200 = FillArray(charbuffer200, 200);

            intbuffer1 = FillArray(intbuffer1, 1);
            intbuffer5 = FillArray(intbuffer5, 5);
            intbuffer20 = FillArray(intbuffer20, 20);
            intbuffer50 = FillArray(intbuffer50, 50);
            intbuffer100 = FillArray(intbuffer100, 100);
            intbuffer200 = FillArray(intbuffer200, 200);

            bytebufferSpecial = FillArray(bytebufferSpecial, int.Parse(this.textBox3.Text));

        }

        private void RunTestSuite()
        {
            this.RunFastByteTestCpp(bytebuffer1);  //preload
            
            
            this.textBox1.Text = "";

            this.RunNormalTest(ref bytebuffer1);
            this.textBox1.Text += "  byte[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref bytebuffer5);
            this.textBox1.Text += "  byte[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref bytebuffer20);
            this.textBox1.Text += " byte[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref bytebuffer50);
            this.textBox1.Text += " byte[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref bytebuffer100);
            this.textBox1.Text += "byte[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref bytebuffer200);
            this.textBox1.Text += "byte[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


            this.RunNormalTest(ref charbuffer1);
            this.textBox1.Text += "  char[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref charbuffer5);
            this.textBox1.Text += "  char[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref charbuffer20);
            this.textBox1.Text += " char[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref charbuffer50);
            this.textBox1.Text += " char[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref charbuffer100);
            this.textBox1.Text += "char[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref charbuffer200);
            this.textBox1.Text += "char[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


            this.RunNormalTest(ref intbuffer1);
            this.textBox1.Text += "   int[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref intbuffer5);
            this.textBox1.Text += "   int[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref intbuffer20);
            this.textBox1.Text += "  int[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref intbuffer50);
            this.textBox1.Text += "  int[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref intbuffer100);
            this.textBox1.Text += " int[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunNormalTest(ref intbuffer200);
            this.textBox1.Text += " int[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";

            this.textBox1.Text += "---------\r\n";
            this.RunNormalTest(ref bytebufferSpecial );
            this.textBox1.Text += " Byte: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


            this.textBox2.Text = "";

            this.RunFastByteTest(bytebuffer1);
            this.textBox2.Text += "  byte[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTest(bytebuffer5);
            this.textBox2.Text += "  byte[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTest(bytebuffer20);
            this.textBox2.Text += " byte[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTest(bytebuffer50);
            this.textBox2.Text += " byte[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTest(bytebuffer100);
            this.textBox2.Text += "byte[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTest(bytebuffer200);
            this.textBox2.Text += "byte[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


            this.RunFastCharTest(charbuffer1);
            this.textBox2.Text += "  char[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastCharTest(charbuffer5);
            this.textBox2.Text += "  char[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastCharTest(charbuffer20);
            this.textBox2.Text += " char[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastCharTest(charbuffer50);
            this.textBox2.Text += " char[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastCharTest(charbuffer100);
            this.textBox2.Text += "char[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastCharTest(charbuffer200);
            this.textBox2.Text += "char[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


            this.RunFastIntTest(intbuffer1);
            this.textBox2.Text += "   int[1]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastIntTest(intbuffer5);
            this.textBox2.Text += "   int[5]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastIntTest(intbuffer20);
            this.textBox2.Text += "  int[20]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastIntTest(intbuffer50);
            this.textBox2.Text += "  int[50]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastIntTest(intbuffer100);
            this.textBox2.Text += " int[100]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastIntTest(intbuffer200);
            this.textBox2.Text += " int[200]: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";

            this.textBox2.Text += "---------\r\n";
            this.RunFastByteTest(bytebufferSpecial);
            this.textBox2.Text += "  Byte c#: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";
            this.RunFastByteTestCpp(bytebufferSpecial);
            this.textBox2.Text += " Byte C++: " + MyTimer.Elapsed.Ticks.ToString() + "\r\n";


        }

        [DllImport("NativeCode.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void NativeBlockCopy(ulong* Src, ulong* Dest, int Count);


        private byte[] FillArray(byte[] ByteArray, int size)
        {
            byte[] Result = new byte[size];

            for (int i = 0; i < size; i++)
                Result[i] = (byte) i;
 
            return Result;


        }

        private char[] FillArray(char[] CharArray, int size)
        {
            char[] Result = new char[size];

            for (int i = 0; i < size; i++)
                Result[i] = (char)i;

            return Result;
        }

        private int[] FillArray(int[] IntArray, int size)
        {
            int[] Result = new int[size];

            for (int i = 0; i < size; i++)
                Result[i] = (int)i;

            return Result;
        }


        private T[] RunNormalTest<T>(ref T[] Arr)
        {
            T[] Dest = new T[Arr.Length];

            MyTimer.Restart();

            for (int i = 0; i<STEPS; i++)
            {
                Buffer.BlockCopy(Arr, 0, Dest, 0, Arr.Length);
            }

            MyTimer.Stop();
            return Dest;
        }

        private Byte[] RunFastByteTest(Byte[] Arr)
        {
            Byte[] Dest = new Byte[Arr.Length];

            MyTimer.Restart();
            for (int i = 0; i < STEPS; i++)
            {
                FastBlockCopy(Arr, 0, Dest, 0, Arr.Length);
            }
            MyTimer.Stop();
            return Dest;
        }

        private Byte[] RunFastByteTestCpp(Byte[] Arr)
        {
            Byte[] Dest = new Byte[Arr.Length];

            MyTimer.Restart();
            for (int i = 0; i < STEPS; i++)
            {
                FastBlockCopyCpp(Arr, 0, Dest, 0, Arr.Length);
            }
            MyTimer.Stop();
            return Dest;
        }


        private char[] RunFastCharTest(char[] Arr)
        {
            char[] Dest = new char[Arr.Length];

            MyTimer.Restart();
            for (int i = 0; i < STEPS; i++)
            {
                FastBlockCopy(Arr, 0, Dest, 0, Arr.Length);
            }
            MyTimer.Stop();
            return Dest;
        }

        private int[] RunFastIntTest(int[] Arr)
        {
            int[] Dest = new int[Arr.Length];

            MyTimer.Restart();
            for (int i = 0; i < STEPS; i++)
            {
                FastBlockCopy(Arr, 0, Dest, 0, Arr.Length);
            }
            MyTimer.Stop();
            return Dest;
        }


        //Normally I would use generics, but you can't take an address of a managed type, so I'm forced to over load the FastBlockCopy function manually.
        private unsafe void FastBlockCopy(byte[] SrcArr, int SrcOffset, byte[] DestArr, int DestOffset, int count)
        {
            int ByteSteps = sizeof(byte);
            int InitialSteps = (count * ByteSteps) % sizeof(uint);
  
            fixed(byte* src = &SrcArr[SrcOffset])
            fixed (byte* dest = &DestArr[DestOffset])
            {
                
                byte* sIndex = src;
                byte* dIndex = dest;
                
                for (int i = 0; i < InitialSteps; i++)
                    *dIndex++ = *sIndex++;

                int Steps = (count - InitialSteps) / sizeof(uint);

                uint* uint_sIndex = (uint*) sIndex;
                uint* uint_dIndex = (uint*) dIndex;

                int p = 0;

                for (; p < (Steps % 5); p++)
                    *uint_dIndex++ = *uint_sIndex++;


                for (; p < Steps; p += 5)
                {
                    *uint_dIndex++ = *uint_sIndex++;
                    *uint_dIndex++ = *uint_sIndex++;
                    *uint_dIndex++ = *uint_sIndex++;
                    *uint_dIndex++ = *uint_sIndex++;
                    *uint_dIndex++ = *uint_sIndex++;
                }


                //for (int i = 0; i<Steps; i++)
                //    *uint_dIndex++ = *uint_sIndex++;
                
            }
        }

        private unsafe void FastBlockCopyCpp(byte[] SrcArr, int SrcOffset, byte[] DestArr, int DestOffset, int count)
        {
            int ByteSteps = sizeof(byte);
            int InitialSteps = (count * ByteSteps) % sizeof(ulong);

            fixed (byte* src = &SrcArr[SrcOffset])
            fixed (byte* dest = &DestArr[DestOffset])
            {

                byte* sIndex = src;
                byte* dIndex = dest;

                for (int i = 0; i < InitialSteps; i++)
                    *dIndex++ = *sIndex++;

                int Steps = (count - InitialSteps) / sizeof(ulong);
 
                NativeBlockCopy((ulong*)sIndex, (ulong*)dIndex, Steps);
                
            }
        }



        private unsafe void FastBlockCopy(char[] SrcArr, int SrcOffset, char[] DestArr, int DestOffset, int count)
        {
            int charSteps = sizeof(char);
            int InitialSteps = (count * charSteps) % sizeof(uint);

            fixed (char* src = &SrcArr[SrcOffset])
            fixed (char* dest = &DestArr[DestOffset])
            {

                char* sIndex = src;
                char* dIndex = dest;

                for (int i = 0; i < InitialSteps; i++)
                    *dIndex++ = *sIndex++;

                uint* uint_sIndex = (uint*)sIndex;
                uint* uint_dIndex = (uint*)dIndex;

                int Steps = (count - InitialSteps) / sizeof(uint);

                for (int i = 0; i < Steps; i++)
                    *uint_dIndex++ = *uint_sIndex++;

            }
        }

        private unsafe void FastBlockCopy(int[] SrcArr, int SrcOffset, int[] DestArr, int DestOffset, int count)
        {
            int intSteps = sizeof(int);
            int InitialSteps = (count * intSteps) % sizeof(uint);

            fixed (int* src = &SrcArr[SrcOffset])
            fixed (int* dest = &DestArr[DestOffset])
            {

                int* sIndex = src;
                int* dIndex = dest;

                for (int i = 0; i < InitialSteps; i++)
                    *dIndex++ = *sIndex++;

                uint* uint_sIndex = (uint*)sIndex;
                uint* uint_dIndex = (uint*)dIndex;
         
                int Steps = (count - InitialSteps) / sizeof(uint);

                for (int i = 0; i < Steps; i++)
                    *uint_dIndex++ = *uint_sIndex++;

            }
        }


    }
}
