using Microsoft.VisualStudio.TestTools.UnitTesting;
using _00_Name_Generator;

namespace _00_Name_Generator_Test
{
    [TestClass]
    public class NameGeneratorTest
    {
        [TestMethod]
        public void GenerateNamesWithCredentials()
        {
            string[] male_n = { "Filip", "Kuba", "Dominik", "Jarek", "Daniel", "Marcin", "Bartek", "Maciej" };
            string[] female_n = { "Wiktoria", "Zuzanna", "Beata", "Paulina", "Magda", "Julka", "Karolina", "Sabina" };
            string[] last_n = { "Nowak", "Wozniak", "Kowalczyk", "Wojcik", "Mazur", "Kaczmarek", "Krawczyk", "Pasieka" };

            NameGenerator ng = new NameGenerator(male_n, female_n, last_n);

            Assert.AreEqual(string.Empty, ng.GetName(false), "String dont builded!");
            Assert.AreNotEqual(string.Empty, ng.GetName(false), "String dont builded434234!");
        }
    }
}
