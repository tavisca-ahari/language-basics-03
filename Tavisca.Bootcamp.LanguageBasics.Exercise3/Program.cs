using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }
        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] bestMenu = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];

            for (int i = 0; i < protein.Length; i++)
                calories[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;

            for (int i = 0; i < dietPlans.Length; i++)
            {
                List<int> tempList = new List<int>();
                List<int> indexList = new List<int>();
               
                for (int j = 0; j < protein.Length; j++)
                    indexList.Add(j);

                for (int j = 0; j < dietPlans[i].Length; j++)
                {
                    tempList = new List<int>();
                    string tempDietPlan = dietPlans[i];
                    if (tempDietPlan[j] == 'C')
                        MaxValue(carbs,tempList,indexList);
                    
                    else if (tempDietPlan[j] == 'c')
                        MinValue(carbs, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 'P')
                        MaxValue(protein, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 'p')
                        MinValue(protein, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 'F')
                        MaxValue(fat, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 'f')
                        MinValue(fat, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 'T')
                        MaxValue(calories, tempList, indexList);
                    
                    else if (tempDietPlan[j] == 't')
                        MinValue(calories, tempList, indexList);
                    
                    if (tempList.Count == 1)
                        break;
                    indexList = tempList;
                }
                if (dietPlans[i] == "")
                    bestMenu[i] = 0;
                else
                    bestMenu[i] = tempList[0];
            }
            return bestMenu;
        }
        public static void MaxValue(int[] nutrition,List<int> tempList, List<int> indexList)
        {
            int max = nutrition[indexList[0]];
            foreach (int k in indexList)
                if (max < nutrition[k])
                    max = nutrition[k];
            foreach (int k in indexList)
                if (max == nutrition[k])
                    tempList.Add(k);
        }
        public static void MinValue(int[] nutrition, List<int> tempList, List<int> indexList)
        {
            int min = nutrition[indexList[0]];
            foreach (int k in indexList)
                if (min > nutrition[k])
                    min = nutrition[k];
            foreach (int k in indexList)
                if (min == nutrition[k])
                    tempList.Add(k);
        }
    }
}
