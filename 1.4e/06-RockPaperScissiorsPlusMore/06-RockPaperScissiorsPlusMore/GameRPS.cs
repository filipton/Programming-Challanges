using _06_RockPaperScissorsPlusMore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _06_RockPaperScissiorsPlusMore
{
    public enum Objects
    {
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock
    }

    public static class GameRPS
    {
        public static bool Play(Objects choose, bool LizardPlusSpock, out Objects pc, out string ErrorCode)
        {
            //Thread.Sleep(250);

            //random object
            Objects ComputerChooseObject = Objects.Rock;

            int ComputerChoose;

            if (LizardPlusSpock)
                ComputerChoose = RandomNumber.Between(0, 4);
            else
                ComputerChoose = RandomNumber.Between(0, 2);


            ComputerChooseObject = ConvertToObject(ComputerChoose);


            pc = ComputerChooseObject;
            ErrorCode = String.Empty;

            if(!LizardPlusSpock)
            {
                if(choose == Objects.Lizard || choose == Objects.Spock)
                {
                    ErrorCode = "Lizard Or Spock is not allowed in this mode.";
                    return false;
                }
            }

            //check who wins
            if (choose == Objects.Rock)
            {
                if (ComputerChooseObject == Objects.Scissors || ComputerChooseObject == Objects.Lizard)
                {
                    return true;
                }
            }
            else if (choose == Objects.Paper)
            {
                if (ComputerChooseObject == Objects.Rock || ComputerChooseObject == Objects.Spock)
                {
                    return true;
                }
            }
            else if (choose == Objects.Scissors)
            {
                if (ComputerChooseObject == Objects.Paper || ComputerChooseObject == Objects.Lizard)
                {
                    return true;
                }
            }
            else if (choose == Objects.Lizard)
            {
                if (ComputerChooseObject == Objects.Paper || ComputerChooseObject == Objects.Spock)
                {
                    return true;
                }
            }
            else if (choose == Objects.Spock)
            {
                if (ComputerChooseObject == Objects.Rock || ComputerChooseObject == Objects.Scissors)
                {
                    return true;
                }
            }

            return false;
        }

        public static Objects ConvertToObject(int number)
        {
            if (number == 0)
                return Objects.Rock;
            else if (number == 1)
                return Objects.Paper;
            else if (number == 2)
                return Objects.Scissors;
            else if (number == 3)
                return Objects.Lizard;
            else if (number == 4)
                return Objects.Spock;

            return Objects.Rock;
        }

        public static Objects ConvertToObject(string name)
        {
            string Name = name.ToLower();

            if (Name == "rock")
                return Objects.Rock;
            else if (Name == "paper")
                return Objects.Paper;
            else if (Name == "scissors")
                return Objects.Scissors;
            else if (Name == "lizard")
                return Objects.Lizard;
            else if (Name == "spock")
                return Objects.Spock;

            return Objects.Rock;
        }
    }

    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }
    }
}