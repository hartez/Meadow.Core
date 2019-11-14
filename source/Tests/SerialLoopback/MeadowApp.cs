﻿using System;
using System.Linq;
using System.Text;
using System.Threading;
using Meadow;
using Meadow.Devices;
using Meadow.Hardware;

namespace SerialLoopback
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        public MeadowApp()
        {
            Console.WriteLine("+SerialLoopback");

            Run();
        }

        void Run()
        {
            Console.WriteLine("Getting ports...");
            var s = F7Serial.GetAvailablePorts();
            Console.WriteLine($"Ports:\n\t{string.Join(' ', s)}");

            Console.WriteLine("Using 'ttyS1'...");
            var port = new SerialPort("ttyS1", 115200);
            Console.WriteLine("\tCreated");
            port.Open();
            if (port.IsOpen)
            {
                Console.WriteLine($"\tOpened {port}");
            }
            else
            {
                Console.WriteLine("\tFailed to Open");
            }

            var buffer = new byte[1024];

            while (true)
            {
                Console.WriteLine("Writing data...");
                var written = port.Write(Encoding.ASCII.GetBytes("Hello Meadow!"));
                Console.WriteLine($"Wrote {written} bytes");

                Console.WriteLine("Reading data...");
                var read = port.Read(buffer, 0, buffer.Length);

                if (read == 0)
                {
                    Console.WriteLine($"Read {read} bytes");
                }
                else
                {
                    Console.WriteLine($"Read {read} bytes: {BitConverter.ToString(buffer, 0, read)}");
                }

                Thread.Sleep(2000);
            }
        }
    }
}