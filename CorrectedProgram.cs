using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningC_List
{
    public class CorrectedProgram
    {
        public static void Main(string[] args)
        {
            //1. Create and initialize lists
            CreateAndInitializeLists(out List<int> numbers, out List<string> country, out List<double> money, out List<string> fruits, out List<string> names);

            //2. Modify lists
            ModifyLists(numbers, country, money, names, fruits);

            //3. Search and check
            SearchAndCheck(names);

            //4. Sort, reverse and clear
            SortReverseClear(names, fruits);

            //5. LINQ examples
            LinqExamples(names, fruits, money);

            //6. Find, select and convert
            FindSelectConvert(names, fruits, money);

            //7. Copy, combine and distinct
            CopyCombineDistinct(fruits, names);

            //8. Grouping and chunking
            GroupingChunking(names, fruits);

            //9. Advanced search
            AdvancedSearch(names, fruits);

            //10. Execution types
            ExecutionTypes(names);

            //11. Utility functions
            UtilityFunctions(names, fruits);
        }




        
        //1. 
        /*-------------CreateAndInitializeLists-------------------------*/
        static void CreateAndInitializeLists(out List<int> numbers, out List<string> country, out List<double> money, out List<string> fruits, out List<string> names)
        {
            numbers = new List<int>();
            country = new List<string>();
            money = new List<double>();

            fruits = new List<string> { "Apple", "Mango", "beatruit", "Bananna", "Water melon", "Pineaple" };
            names = new List<string> { "David", "Iyanu", "Ohibor", "Emmanuel", "Buhari", "Tinubu", "Akeredolu", "Aketi" };
        }

        //2.
        /*-----------ModifyLists---------------------------*/
        static void ModifyLists(List<int> numbers, List<string> country, List<double> money, List<string> names, List<string> fruits)
        {
            numbers.AddRange(Enumerable.Range(1, 10));
            country.AddRange(new List<string> { "Nigeria", "Chana", "Coutonu", "Iraq" });
            money.AddRange(new List<double> { 10.0, 11.50, 13.20, 14.30, 15.70 });
            names.AddRange(new List<string> { "Ada", "Ngozi", "Chidinma", "Chinozo" });
            names.Insert(1, "King");
            numbers.Remove(1);
            fruits.RemoveAt(1);
        }

        //3.
        /*-----------SearchAndCheck---------------------------*/
        static void SearchAndCheck(List<string> names)
        {
            names.RemoveAll(f => f.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            bool hasA = names.Any(n => n.Contains("a", StringComparison.OrdinalIgnoreCase));
            int index = names.IndexOf("Iyanu");
            string firstName = names[0];
            names[0] = "Kiwi";
            Console.WriteLine($"Has 'a': {hasA}, Index of Iyanu: {index}, First Name: {firstName}");
        }

        //4.
        /*-----------SortReverseClear---------------------------*/
        static void SortReverseClear(List<string> names, List<string> fruits)
        {
            names.Sort(StringComparer.OrdinalIgnoreCase);
            names.Reverse();
            fruits.Clear();
        }

        //5.
        /*-----------LinqExamples---------------------------*/
        static void LinqExamples(List<string> names, List<string> fruits, List<double> money)
        {
            var filtered = fruits.Where(f => f.Length > 2).ToList();
            var moneyOrder = money.OrderBy(f => f).ToList();
            Console.WriteLine($"Sum of money: {money.Sum()}, Any > 3: {money.Any(f => f > 3)}, All > 3: {money.All(f => f > 3)}");
        }

        //6.
        /*-----------FindSelectConvert---------------------------*/
        static void FindSelectConvert(List<string> names, List<string> fruits, List<double> money)
        {
            string? findingName = names.Find(f => f.StartsWith("k", StringComparison.OrdinalIgnoreCase));
            List<string> findAll = names.FindAll(f => f.StartsWith("c", StringComparison.OrdinalIgnoreCase));
            string[] nameArray = names.ToArray();
            string moneyStr = string.Join(",", money);
        }

        //7.
        /*-----------CopyCombineDistinct---------------------------*/
        static void CopyCombineDistinct(List<string> fruits, List<string> names)
        {
            var newFruits = fruits.Concat(new List<string> { "Lemon", "Melon", "Grape", "Melon", "Grape", "Cashew" }).ToList();
            var uniqueFruits = newFruits.Distinct().ToList();
            var nameBackup = new List<string>(names);
        }

        //8.
        /*-----------GroupingChunking---------------------------*/
        static void GroupingChunking(List<string> names, List<string> fruits)
        {
            var groups = names.GroupBy(f => f.Length);
            foreach (var g in groups)
            {
                Console.WriteLine($"Length {g.Key}: {string.Join(", ", g)}");
            }

            int chunkSize = 2;
            for (int i = 0; i < fruits.Count; i += chunkSize)
            {
                var chunk = fruits.Skip(i).Take(chunkSize).ToList();
                Console.WriteLine(string.Join(", ", chunk));
            }

            var sublist = names.GetRange(1, 2);
        }

        //9.
        //-----------AdvancedSearch---------------------------
        static void AdvancedSearch(List<string> names, List<string> fruits)
        {
            string? result = fruits.FirstOrDefault(f => f.Contains("z"));
            var lengths = fruits.Select(f => f.Length).ToList();
            int maxLength = names.Max(f => f.Length);
            int indexByCondition = names.FindIndex(f => f.StartsWith("K", StringComparison.OrdinalIgnoreCase));
            string? lastMatching = names.FindLast(f => f.StartsWith("a", StringComparison.OrdinalIgnoreCase));
        }

        //10.
        /*-----------ExecutionTypes---------------------------*/
        static void ExecutionTypes(List<string> names)
        {
            var querySyntax = from name in names where name.Length > 5 orderby name select name;
            var deferredQuery = names.Where(n => n.Length > 5);
            var immediateQuery = names.Where(n => n.Length > 5).ToList();
            var groupedByCount = names.GroupBy(n => n.Length)
                                      .Select(g => new { g.Key, Count = g.Count() })
                                      .ToList();
        }

        //11.
        /*-----------UtilityFunctions---------------------------*/
        static void UtilityFunctions(List<string> names, List<string> fruits)
        {
            bool equal = fruits.SequenceEqual(names);
            bool hasDupes = names.Count != fruits.Distinct().Count();
            names.RemoveAll(f => f.Length < 5);
            names.RemoveRange(0, 2);
            names.Sort();
            int binaryIndex = names.BinarySearch("Emmanuel", StringComparer.OrdinalIgnoreCase);
            bool allStartsWithE = names.TrueForAll(f => f.StartsWith("E", StringComparison.OrdinalIgnoreCase));
            List<string> shuffled = names.OrderBy(x => new Random().Next()).ToList();
        }














    }
}