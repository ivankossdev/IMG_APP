﻿
using System.Text;

namespace img_app;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start app");
        string path = "/home/ivan/developer/DotnetCore/IMG_APP/3c.bmp";
        Console.WriteLine(path);
        using (FileStream fstream = File.OpenRead(path))
        {
            byte[] buffer = new byte[fstream.Length];

            fstream.Read(buffer, 0, buffer.Length);
            Console.WriteLine($"Len file {buffer.Length} byte. ");
            GetHader(buffer);
            System.Console.WriteLine();
            for (int i = 14; i < 0x18; i++)
            {
                Console.WriteLine($"[{i}] {buffer[i]}");
            }
        }
    }

    static void GetHader(byte[] buf)
    {
        Console.WriteLine("Haeder file\n");
        for (int i = 0; i < 14; i++)
        {
            if (i == 0 || i == 1)
            {
                Console.WriteLine($"[{i}] {Convert.ToChar(buf[i])}");
            }
            else if (i >= 6 && i < 10)
            {
                Console.WriteLine($"[{i}] {buf[i]} Reserved created app");
            }
            else
            {
                Console.WriteLine($"[{i}] {buf[i]}");
            }
        }
    }
}
