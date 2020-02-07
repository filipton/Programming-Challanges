using System;
using System.Threading;

namespace _01_Higher_Lower_Heads_Tails
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:

            Console.Clear();

            Console.WriteLine("Choose option:");
            Console.WriteLine("1) Higher/Lower");
            Console.WriteLine("2) Heads/Tails");
            Console.WriteLine("3) Quit");

            try
            {
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                        HigherOrLowerInit();
                        break;
                    case 2:
                        HeadOrTailInit();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect value... try again!");
                        Thread.Sleep(1500);
                        goto Start;
                }
            }
            catch
            {
                Console.WriteLine("Unhandled Exception...");
                Thread.Sleep(2500);
                Console.Clear();
                goto Start;
            }
        }

        public static void WantToPlayerAgain(int game)
        {
            if (game == 1)
            {
                Console.WriteLine("Want to play again? [Y]es/[N]o");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        HigherOrLowerInit();
                        break;
                    case "yes":
                        HigherOrLowerInit();
                        break;
                    case "n":
                        Main(new string[] { });
                        break;
                    case "no":
                        Main(new string[] { });
                        break;
                }
            }
            else if (game == 2)
            {
                Console.WriteLine("Want to play again? [Y]es/[N]o");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        HeadOrTailInit();
                        break;
                    case "yes":
                        HeadOrTailInit();
                        break;
                    case "n":
                        Main(new string[] { });
                        break;
                    case "no":
                        Main(new string[] { });
                        break;
                }
            }
        }

        public static void HigherOrLowerInit()
        {
            Console.Clear();
            Console.WriteLine("What should be the largest number? (Minimum 2)");
            int maxint = int.Parse(Console.ReadLine());
            Console.WriteLine("What should be the maximum of attemps? (Minimum 1)");
            int maxattemps = int.Parse(Console.ReadLine());
            HigherOrLower(maxint, maxattemps);
        }

        public static void HigherOrLower(int max_int = 20, int max_attemps = 10)
        {
            if (max_attemps == 0)
                max_attemps = 10; // 10 - default value

            if (max_int <= 1)
                max_int = 20; //20 - default value


            int number_to_find = new Random().Next(1, max_int+1); //+1 because max int is last int not before last int

            int i = 0;
            while(i < max_attemps)
            {
                i++;

                int guess = int.Parse(Console.ReadLine());

                if(guess > number_to_find)
                {
                    Console.WriteLine("Lower!");
                }
                else if(guess < number_to_find)
                {
                    Console.WriteLine("Higher!");
                }
                else if (guess == number_to_find)
                {
                    Console.WriteLine($"YEAH! YOU ARE THE BEST! YOU ARE DO THIS IN: {i}/{max_attemps} ATTEMPS!");
                    WantToPlayerAgain(1);
                    return;
                }

                if(i == max_attemps)
                {
                    Console.WriteLine($"Maximum attempts reached... This int is: {number_to_find}.");
                    WantToPlayerAgain(1);
                }
            }
        }


        public static void HeadOrTailInit()
        {
            choose_point:

            Console.Clear();
            Console.WriteLine("What do you choose? Head or Tail?");
            string choose = Console.ReadLine().ToLower();
            int choose_int;

            if (choose.Equals("head"))
            {
                choose_int = 0;
            }
            else if (choose.Equals("tail"))
            {
                choose_int = 1;
            }
            else
            {
                Console.WriteLine("Wrong String... Try again!");
                Thread.Sleep(1500);
                goto choose_point;
            }

            HeadOrTail(choose_int);
        }

        public static void HeadOrTail(int choose)
        {
            int coin = new Random().Next(0, 2); // output: 0 - 1
            bool choosed_bool = Convert.ToBoolean(coin);
            string coin_s = choosed_bool ? "Tail" : "Head";

            if(choose == coin)
            {
                Console.WriteLine($"You are won! Coin showed {coin_s}.");
                WantToPlayerAgain(2);
            }
            else
            {
                Console.WriteLine($"You are lose! Coin showed {coin_s}.");
                WantToPlayerAgain(2);
            }
        }
    }
}
