using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Reverse_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Put text you want to reverse:");

            Console.WriteLine(ReverseString(Console.ReadLine()));
            Console.ReadLine();
        }

        public static string ReverseString(string texttoreverse)
        {
            char[] stringchars = new char[texttoreverse.Length];

            //get all chars from string
            StringReader sr = new StringReader(texttoreverse);
            sr.Read(stringchars, 0, texttoreverse.Length);

            //convert array to list 
            List<char> textchars = stringchars.ToList();

            //reverse list
            textchars.Reverse();

            //build string
            StringBuilder reversedString = new StringBuilder();

            for(int i = 0; i < textchars.Count; i++)
            {
                reversedString.Append(textchars[i]);
            }

            return reversedString.ToString();
        }
    }
}