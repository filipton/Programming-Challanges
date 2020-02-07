using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace _28_Fibonacci_Sequence
{
    class Program
    {
        public static bool StopBool = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1) Until Stop");
            Console.WriteLine("2) Input index, get output.");
            Console.WriteLine("3) Exit");


            start:
            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    Thread threadUntilStop = new Thread(PrintFibonacciNumbers);
                    threadUntilStop.Start();
                    break;
                case "2":
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(GetFibonacciNumberAtIndex((BigInteger.Parse(Console.ReadLine())) + 1));
                        }
                        catch { }
                    }
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    goto start;
            }

            Console.ReadLine();
        }

        public static BigInteger GetFibonacciNumberAtIndex(BigInteger index)
        {
            BigInteger a = 0;
            BigInteger b = 1;

            BigInteger c = 0;

            for(BigInteger i = 2; i < index; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        public static void PrintFibonacciNumbers()
        {
            BigInteger Times = 0;

            BigInteger a = 0;
            BigInteger b = 1;

            BigInteger c = 0;

            while (StopBool == true)
            {
                c = a + b;
                a = b;
                b = c;

                Console.WriteLine(c);
                Thread.Sleep(0);
                Times++;
                Console.Title = Times.ToString();
            }
        }
    }
}