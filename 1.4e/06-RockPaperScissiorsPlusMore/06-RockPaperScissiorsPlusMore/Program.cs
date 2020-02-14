using _06_RockPaperScissiorsPlusMore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_RockPaperScissorsPlusMore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Play With Computer");
            Console.WriteLine("2) Start Tests");

            int mode = int.Parse(Console.ReadLine());
            switch(mode)
            {
                case 1:
                    Console.Clear();
                    PlayWithComputer();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter Count of tests.");
                    Tests test = new Tests();
                    test.RunTest(ulong.Parse(Console.ReadLine()));
                    break;
            }


            Console.ReadLine();
        }

        public static void PlayWithComputer()
        {
            bool LPSBool = false;

            Console.WriteLine("Do you want to play with lizard and spock? (1 or yes etc.)");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No");

            switch(Console.ReadLine().ToLower())
            {
                case "1": case "yes":
                    LPSBool = true;
                    break;
                case "2": case "no":
                    LPSBool = false;
                    break;
            }
            Console.Clear();

            Console.WriteLine("Enter object you want to use (number or name):");
            Console.WriteLine("1) Rock");
            Console.WriteLine("2) Paper");
            Console.WriteLine("3) Scissors");
            Console.WriteLine("4) Lizard");
            Console.WriteLine("5) Spock");

            string obj = Console.ReadLine();
            Objects MyObject = Objects.Rock;

            Console.Clear();

            if (int.TryParse(obj, out int ChoosedObject))
                MyObject = GameRPS.ConvertToObject(ChoosedObject);
            else
                MyObject = GameRPS.ConvertToObject(obj);

            string Output = string.Empty;

            if(GameRPS.Play(MyObject, LPSBool, out Objects pcObject, out string error))
            {
                Output = $"You are won! {MyObject} vs {pcObject}";
            }
            else
            {
                if(!string.IsNullOrEmpty(error))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error: {error}");
                    Console.ResetColor();
                }
                else
                {
                    Output = $"You are lose! {MyObject} vs {pcObject}";
                }
            }

            Console.WriteLine(Output);

            Console.WriteLine("Press any key to go the Menu!");
            Console.ReadKey();

            Console.Clear();

            Main(new string[] { });
        }
    }
}