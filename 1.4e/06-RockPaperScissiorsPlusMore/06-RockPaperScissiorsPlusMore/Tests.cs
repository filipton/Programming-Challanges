using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_RockPaperScissiorsPlusMore
{
    class Tests
    {
        public int WinCount, LoseCount, RemisCount;

        public void RunTest(ulong Times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool LizardPlusSpock = true;
            ulong RepeatCount = Times;

            for (ulong i = 0; i < RepeatCount; i++)
            {
                Objects MyChoose = Objects.Rock;

                int ComputerChoose;

                if (LizardPlusSpock)
                    ComputerChoose = RandomNumber.Between(0, 4);
                else
                    ComputerChoose = RandomNumber.Between(0, 2);


                MyChoose = GameRPS.ConvertToObject(ComputerChoose);

                Objects pcChoose;

                bool YouWin = GameRPS.Play(MyChoose, LizardPlusSpock, out pcChoose, out string error);

                //if remis
                if (MyChoose == pcChoose)
                {
                    Console.WriteLine($"Remis! {MyChoose} vs {pcChoose}");
                    RemisCount++;
                }
                else
                {
                    if (YouWin)
                    {
                        Console.WriteLine($"You Win! {MyChoose} vs {pcChoose}");
                        WinCount++;
                    }
                    else
                    {
                        Console.WriteLine($"You Lose! {MyChoose} vs {pcChoose}");
                        LoseCount++;
                    }
                }


                //Thread.Sleep(250);
            }

            sw.Stop();

            Thread.Sleep(1000);
            Console.Clear();

            double WinRate = (double)WinCount / (double)RepeatCount;
            double LoseRate = (double)LoseCount / (double)RepeatCount;
            double RemisRate = (double)RemisCount / (double)RepeatCount;

            Console.WriteLine($"Summary: WinCount: {WinCount} (Rate: {WinRate.ToString("P5")}), LoseCount: {LoseCount} (Rate: {LoseRate.ToString("P5")}), RemisCount: {RemisCount} (Rate: {RemisRate.ToString("P5")})");
            Console.WriteLine($"Total elapsed time: {sw.Elapsed}");
        }
    }
}