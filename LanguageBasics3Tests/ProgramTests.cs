using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Bootcamp.LanguageBasics.Exercise3;

namespace LanguageBasics3
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DietPlan_Simple()
        {
            // Arrange
            int[] protein = new[] { 3, 4 };
            int[] carbs = new[] { 2, 8 };
            int[] fat = new[] { 5, 2 };
            string[] dietPlans = new[] { "P", "p", "C", "c", "F", "f", "T", "t" };
            int[] expected = new[] { 1, 0, 1, 0, 0, 1, 1, 0 };

            // Act
            int[] actual = Program.SelectMeals(protein, carbs, fat, dietPlans);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DietPlan_Tied()
        {
            //Arrange
            int[] protein = new[] { 3, 4, 1, 5 };
            int[] carbs = new[] { 2, 8, 5, 1 };
            int[] fat = new[] { 5, 2, 4, 4 };
            string[] dietPlans = new[] { "tFc", "tF", "Ftc" };
            int[] expected = new[] { 3, 2, 0 };

            //Act
            int[] actual = Program.SelectMeals(protein, carbs, fat, dietPlans);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DietPlan_Empty()
        {
            //Arrange
            int[] protein = new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 };
            int[] carbs = new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 };
            int[] fat = new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 };
            string[] dietPlans = new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" };
            int[] expected = new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 };

            //Act
            int[] actual = Program.SelectMeals(protein, carbs, fat, dietPlans);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
