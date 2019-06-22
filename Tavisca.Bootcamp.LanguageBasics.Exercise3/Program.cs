using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
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
            int[] output = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];

            
            for (int i = 0; i < protein.Length; i++)
                calories[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;


            for (int i = 0; i < dietPlans.Length; i++)
            {
                List<int> temp = new List<int>();
                List<int> List = new List<int>();
                int min=10000, max=-1;
                for (int j = 0; j < protein.Length; j++)
                    List.Add(j);
                for (int j = 0; j < dietPlans[i].Length; j++)
                {
                    temp = new List<int>();
                    string tempDietPlan = dietPlans[i];
                    if (tempDietPlan[j] == 'C')
                    { 
                        foreach (int k in List)
                            if (max < carbs[k])
                                max = carbs[k];
                        foreach (int k in List)
                            if (max == carbs[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'c')
                    {
                        foreach (int k in List)
                            if (min > carbs[k])
                                min = carbs[k];
                        foreach (int k in List)
                            if (min == carbs[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'P')
                    {
                        foreach (int k in List)
                            if (max < protein[k])
                                max = protein[k];
                        foreach (int k in List)
                            if (max == protein[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'p')
                    {
                        foreach (int k in List)
                            if (min > protein[k])
                                min = protein[k];
                        foreach (int k in List)
                            if (min == protein[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'F')
                    {
                        foreach (int k in List)
                            if (max < fat[k])
                                max = fat[k];
                        foreach (int k in List)
                            if (max == fat[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'f')
                    {
                       
                        foreach (int k in List)
                            if (min > fat[k])
                                min = fat[k];
                        foreach (int k in List)
                            if (min == fat[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 'T')
                    {
                        
                        foreach (int k in List)
                            if (max < calories[k])
                                max = calories[k];
                        foreach (int k in List)
                            if (max == calories[k])
                                temp.Add(k);
                    }
                    else if (tempDietPlan[j] == 't')
                    {
                        
                        foreach (int k in List)
                            if (min > calories[k])
                                min = calories[k];
                        foreach (int k in List)
                            if (min == calories[k])
                                temp.Add(k);
                    }
                    if (temp.Count == 1)
                        break;
                    List = temp;
                }
                if (dietPlans[i] == "")
                    output[i] = 0;
                else
                    output[i] = temp[0];
            }
            return output;
        }
    }
}
