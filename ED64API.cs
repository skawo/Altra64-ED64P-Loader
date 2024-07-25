using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;

namespace ED64PLoad
{
    public class ED64API
    {
        static byte[] writeBuf;
        static byte[] recvBuf;
        public static bool DoingStuff = false;

        public static void setED64API(string Port)
        {
            try
            {
                if (DoingStuff)
                    return;

                if (Program.port != null)
                {
                    if (Program.port.IsOpen)
                        Program.port.Close();
                }

                Program.port = new SerialPort(Port, 9600, Parity.None, 8, StopBits.One);
                Program.port.WriteTimeout = 1000;
                Program.port.ReadTimeout = 1000;
                Program.port.Open();
            }
            catch (Exception)
            { }
        }

        public static bool ED64TestPort()
        {
            if (Program.port == null)
                return false;

           DoingStuff = true;
           bool Res = false;

            try
            {
                writeBuf = new byte[512];
                writeBuf[0] = (byte)'C';
                writeBuf[1] = (byte)'M';
                writeBuf[2] = (byte)'D';
                writeBuf[3] = (byte)'T';

                Program.port.Write(writeBuf, 0, 512);
                Thread.Sleep(100);
                recvBuf = new byte[512];
                Program.port.Read(recvBuf, 0, 512);

                Res = CheckForReply();
            }
            catch (TimeoutException) { }
            catch (Exception ex)
            {
            }

            DoingStuff = false;
            return Res;
        }

        public static void Destroy()
        {
            DoingStuff = true;
            if (Program.port != null)
            {
                if (Program.port.IsOpen)
                    Program.port.Close();
            }
            DoingStuff = false;
        }

        public static bool ED64SendROM(byte[] LoadedROM, BackgroundWorker bw)
        {
            if (Program.port == null)
                return false;

            DoingStuff = true;
            bool Res = false;

            int RL = LoadedROM.Length;

            while (RL % 0x200 != 0)
                RL++;

            byte[] ROM = new byte[RL];
            Array.Copy(LoadedROM, ROM, LoadedROM.Length);

            try
            {
                if (ROM.Length < 0x200000)
                {
                    writeBuf = new byte[512];
                    writeBuf[0] = (byte)'C';
                    writeBuf[1] = (byte)'M';
                    writeBuf[2] = (byte)'D';
                    writeBuf[3] = (byte)'F';

                    Program.port.Write(writeBuf, 0, 512);
                    Thread.Sleep(100);
                    recvBuf = new byte[512];
                    Program.port.Read(recvBuf, 0, 512);

                    Res = CheckForReply();

                    if (!Res)
                        throw new Exception("FILL did not succeed?");
                }


                writeBuf = new byte[512];
                writeBuf[0] = (byte)'C';
                writeBuf[1] = (byte)'M';
                writeBuf[2] = (byte)'D';
                writeBuf[3] = (byte)'W';
                writeBuf[6] = (byte)((ROM.Length / 0x200) >> 8);
                writeBuf[7] = (byte)(ROM.Length / 0x200);

                Program.port.Write(writeBuf, 0, 512);

                int BUF_SIZE = Math.Min(ROM.Length, 2 * 0x8000);
                float StepsNum = ROM.Length / BUF_SIZE;
                float StepCur = 0;
                int SizeLeft = ROM.Length;

                for (int i = 0; i < ROM.Length; i+= BUF_SIZE)
                {
                    if (i == 0x2000000)
                    {
                        writeBuf = new byte[512];
                        writeBuf[0] = (byte)'C';
                        writeBuf[1] = (byte)'M';
                        writeBuf[2] = (byte)'D';
                        writeBuf[3] = (byte)'W';
                        writeBuf[4] = 0x40;

                        Program.port.Write(writeBuf, 0, 512);
                    }

                    if (BUF_SIZE > SizeLeft)
                        BUF_SIZE = SizeLeft;

                    writeBuf = new byte[BUF_SIZE];
                    Array.Copy(ROM, i, writeBuf, 0, BUF_SIZE);
                    Program.port.Write(writeBuf, 0, BUF_SIZE);
                    StepCur++;
                    SizeLeft -= BUF_SIZE;

                    float Progress = (StepCur / StepsNum * 100.0f);
                    bw.ReportProgress( (int)Progress);
                }

                writeBuf = new byte[512];
                writeBuf[0] = (byte)'C';
                writeBuf[1] = (byte)'M';
                writeBuf[2] = (byte)'D';
                writeBuf[3] = (byte)'S';

                Program.port.Write(writeBuf, 0, 512);
            }
            catch (Exception ex)
            {
            }

            DoingStuff = false;
            return Res;
        }

        private static bool CheckForReply()
        {
            if (recvBuf[3] == (byte)'k')
                return true;
            else
                return false;
        }
    }
}
