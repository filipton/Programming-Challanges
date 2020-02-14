using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Yout Weight (in kilograms):");
            float weight = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Yout Height (in centymeters):");
            float height = float.Parse(Console.ReadLine());

            Console.WriteLine($"Your bmi is: {CalcBMI(weight, height)}");
            Console.ReadLine();
        }

        public static float CalcBMI(float kg, float height)
        {
            float bmi = (kg / (float)Math.Pow(height, 2)) * 10000;
            bmi = (float)Math.Round(bmi, 1);

            return bmi;
        }
    }
}