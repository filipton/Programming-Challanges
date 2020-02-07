using System;
using System.Text;
using System.Threading;

namespace _00_Name_Generator
{
    public class NameGenerator
    {
        string[] male_names;
        string[] female_names;

        string[] last_names;

        private NameGenerator() { }
        public NameGenerator(string[] malenames, string[] femalenames, string[] lastnames)
        {
            male_names = malenames;
            female_names = femalenames;
            last_names = lastnames;
        }

        public string GetName(bool male)
        {
            Thread.Sleep(250);
            return BuildName(male);
        }

        string BuildName(bool male)
        {
            string name = String.Empty;

            if (male)
                name += $"{male_names[new Random().Next(0, male_names.Length)]} ";
            else
                name += $"{female_names[new Random().Next(0, female_names.Length)]} ";

            name += last_names[new Random().Next(0, last_names.Length)];

            return "";
        }

        string BuildNameWithStringBuilder(bool male)
        {
            StringBuilder builder = new StringBuilder();

            if (male)
                builder.Append($"{male_names[new Random().Next(0, male_names.Length)]} ");
            else
                builder.Append($"{female_names[new Random().Next(0, female_names.Length)]} ");

            builder.Append(last_names[new Random().Next(0, last_names.Length)]);

            return builder.ToString();
        }

        public static void Main()
        {
            string[] male_n = { "Filip", "Kuba", "Dominik", "Jarek", "Daniel", "Marcin", "Bartek", "Maciej" };
            string[] female_n = { "Wiktoria", "Zuzanna", "Beata", "Paulina", "Magda", "Julka", "Karolina", "Sabina" };
            string[] last_n = { "Nowak", "Wozniak", "Kowalczyk", "Wojcik", "Mazur", "Kaczmarek", "Krawczyk", "Pasieka" };

            Console.WriteLine(new NameGenerator(male_n, female_n, last_n).GetName(true));
            Console.WriteLine(new NameGenerator(male_n, female_n, last_n).GetName(false));
            Console.ReadLine();
        }
    }
}
