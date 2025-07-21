using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningC_List
{
    public class CorrectedProgram
    {
        /*-------------Delegate and Event Messenger-------------------------*/
        public delegate void ListEventHandler(string message);// Delegate for handling list events
        public class EventMessenger
        {
            public event ListEventHandler? OnNotify; // Event to notify about list operations
            public void Notify(string message)
            {
                OnNotify?.Invoke(message);// Invoke the event if there are any subscribers
            }
        }
        /*-------------End of Delegate and Event Messenger-------------------------*/





        public static void Main(string[] args)
        {
            var messenger = new EventMessenger();

            //1. Create and initialize lists
            CreateAndInitializeLists(out List<int> numbers, out List<string> country, out List<double> money, out List<string> fruits, out List<string> names);

            //2. Modify lists
            ModifyLists(numbers, country, money, names, fruits);

            //3. Search and check
            messenger.OnNotify += (msg) => Console.WriteLine(msg);// Subscribe to the event
            SearchAndCheck(names, messenger);

            //4. Sort, reverse and clear
            messenger.OnNotify += (msg) => Console.WriteLine("Sort, Reverse, Clear: " + msg);// Subscribe to the event for sort, reverse and clear
            SortReverseClear(names, fruits, messenger);

            //5. LINQ examples
            messenger.OnNotify += (msg) => Console.WriteLine("LINQ: " + msg);// Subscribe to the event for LINQ operations
            LinqExamples(names, fruits, money, messenger);

            //6. Find, select and convert
            messenger.OnNotify += (msg) => Console.WriteLine("Find, Select, Convert: " + msg);// Subscribe to the event for find, select and convert    
            FindSelectConvert(names, fruits, money,messenger);

            //7. Copy, combine and distinct
            messenger.OnNotify += (msg) => Console.WriteLine("Copy, Combine, Distinct: " + msg);// Subscribe to the event for copy, combine and distinct
            CopyCombineDistinct(fruits, names, messenger);

            //8. Grouping and chunking
            messenger.OnNotify += (msg) => Console.WriteLine("Grouping, Chunking: " + msg);// Subscribe to the event for grouping and chunking
            GroupingChunking(names, fruits, messenger);

            //9. Advanced search
            messenger.OnNotify += (msg) => Console.WriteLine("Advanced Search: " + msg);// Subscribe to the event for advanced search
            AdvancedSearch(names, fruits, messenger);

            //10. Execution types
            messenger.OnNotify += (msg) => Console.WriteLine("Execution Types: " + msg);// Subscribe to the event for execution types
            ExecutionTypes(names, messenger);

            //11. Utility functions
            messenger.OnNotify += (msg) => Console.WriteLine("Utility Functions: " + msg);// Subscribe to the event for utility functions       
            UtilityFunctions(names, fruits, messenger);
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
        static void SearchAndCheck(List<string> names, EventMessenger messenger)
        {
            try
            {
                names.RemoveAll(f => f.StartsWith("A", StringComparison.OrdinalIgnoreCase));
                messenger.Notify("Removed names starting with 'A'");

                bool hasA = names.Any(n => n.Contains("a", StringComparison.OrdinalIgnoreCase));
                messenger.Notify(hasA? "At least one name contains 'a'" : "No names contain 'a'");

                int index = names.IndexOf("Iyanu");
                if (index >=0) messenger.Notify("'Iyanu' found at index " + index);
                else messenger.Notify("'Iyanu' not found at index" + index);


                string firstName = names[0];
                names[0] = "Kiwi";
                messenger.Notify($"Changed first name from '{firstName}' to 'Kiwi'");


                Console.WriteLine($"Has 'a': {hasA}, Index of Iyanu: {index}, First Name: {firstName}");
            }
            catch (Exception ex)
            {
                messenger.Notify("Error in SearchAndCheck: " + ex.Message);
            }
        }

        //4.
        /*-----------SortReverseClear---------------------------*/
        static void SortReverseClear(List<string> names, List<string> fruits, EventMessenger messenger)
        {
            try
            {
                names.Sort(StringComparer.OrdinalIgnoreCase);
                names.Reverse();
                fruits.Clear();
                messenger.Notify("Sorted names, reversed them, and cleared fruits list.");
                messenger.Notify($"Sorted names: {string.Join(", ", names)}");
                messenger.Notify($"Reversed names: {string.Join(", ", names)}");
                
            }
            catch (Exception ex)
            {

                messenger.Notify("An error occurred while sorting, reversing, or clearing the lists.");
                messenger.Notify($"An error occurred: {ex.Message}");
            }
        }

        //5.
        /*-----------LinqExamples---------------------------*/
        static void LinqExamples(List<string> names, List<string> fruits, List<double> money, EventMessenger messenger)
        {
            try
            {
                var filtered = fruits.Where(f => f.Length > 2).ToList();
                var moneyOrder = money.OrderBy(f => f).ToList();
                messenger.Notify($"Filtered fruits: {string.Join(", ", filtered)}");
                messenger.Notify($"Ordered money: {string.Join(", ", moneyOrder)}");
            }
            catch (Exception ex)
            {
                messenger.Notify("An error occurred while performing LINQ operations.");
                messenger.Notify($"An error occurred: {ex.Message}");
               
            }
        }

        //6.
        /*-----------FindSelectConvert---------------------------*/
        static void FindSelectConvert(List<string> names, List<string> fruits, List<double> money, EventMessenger messenger)
        {
           try
           {
             string? findingName = names.Find(f => f.StartsWith("k", StringComparison.OrdinalIgnoreCase));
            List<string> findAll = names.FindAll(f => f.StartsWith("c", StringComparison.OrdinalIgnoreCase));
            string[] nameArray = names.ToArray();
            string moneyStr = string.Join(",", money);
           }
           catch (Exception ex)
           {
            
            Console.WriteLine("An error occurred while finding, selecting, or converting.");
            Console.WriteLine($"An error occurred: {ex.Message}");
           }
        }

        //7.
        /*-----------CopyCombineDistinct---------------------------*/
        static void CopyCombineDistinct(List<string> fruits, List<string> names, EventMessenger messenger)
        {
            try
            {
                var newFruits = fruits.Concat(new List<string> { "Lemon", "Melon", "Grape", "Melon", "Grape", "Cashew" }).ToList();
                var uniqueFruits = newFruits.Distinct().ToList();
                var nameBackup = new List<string>(names);
                messenger.Notify($"Combined fruits: {string.Join(", ", newFruits)}");
                messenger.Notify($"Distinct fruits: {string.Join(", ", uniqueFruits)}");
            }
            catch (Exception ex)
            {
                messenger.Notify("An error occurred while copying, combining, or getting distinct values.");
                messenger.Notify($"An error occurred: {ex.Message}");
               
            }
        }

        //8.
        /*-----------GroupingChunking---------------------------*/
        static void GroupingChunking(List<string> names, List<string> fruits, EventMessenger messenger)
        {
            try
            {
                var groups = names.GroupBy(f => f.Length);
                foreach (var g in groups)
                {
                    messenger.Notify($"Length {g.Key}: {string.Join(", ", g)}");
                }

                int chunkSize = 2;
                for (int i = 0; i < fruits.Count; i += chunkSize)
                {
                    var chunk = fruits.Skip(i).Take(chunkSize).ToList();
                    messenger.Notify(string.Join(", ", chunk));
                }

                var sublist = names.GetRange(1, 2);
            }
            catch (Exception ex)
            {
                messenger.Notify("An error occurred while grouping or chunking the lists.");
                messenger.Notify($"An error occurred: {ex.Message}");
            }
        }

        //9.
        //-----------AdvancedSearch---------------------------
        static void AdvancedSearch(List<string> names, List<string> fruits, EventMessenger messenger)
        {
            try
            {
                string? result = fruits.FirstOrDefault(f => f.Contains("z"));
                var lengths = fruits.Select(f => f.Length).ToList();
                int maxLength = names.Max(f => f.Length);
                int indexByCondition = names.FindIndex(f => f.StartsWith("K", StringComparison.OrdinalIgnoreCase));
                string? lastMatching = names.FindLast(f => f.StartsWith("a", StringComparison.OrdinalIgnoreCase));
                messenger.Notify($"First fruit containing 'z': {result}");
                messenger.Notify($"Lengths of fruits: {string.Join(", ", lengths)}");
           }
            catch (Exception ex)
            {
                messenger.Notify("An error occurred while performing advanced search operations.");
                messenger.Notify($"An error occurred: {ex.Message}");
            }
        }

        //10.
        /*-----------ExecutionTypes---------------------------*/
        static void ExecutionTypes(List<string> names, EventMessenger messenger)
        {
           try
           {
             var querySyntax = from name in names where name.Length > 5 orderby name select name;
            var deferredQuery = names.Where(n => n.Length > 5);
            var immediateQuery = names.Where(n => n.Length > 5).ToList();
            var groupedByCount = names.GroupBy(n => n.Length)
                                      .Select(g => new { g.Key, Count = g.Count() })
                                      .ToList();
           }
           catch (Exception ex)
           {
            messenger.Notify("An error occurred while executing LINQ queries.");
            messenger.Notify($"An error occurred: {ex.Message}");
           
           }
        }

        //11.
        /*-----------UtilityFunctions---------------------------*/
        static void UtilityFunctions(List<string> names, List<string> fruits, EventMessenger messenger)
        {
            try
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
            catch (Exception ex)
            {
                messenger.Notify("An error occurred while performing utility functions.");
                messenger.Notify($"An error occurred: {ex.Message}");
               
            }
        }














    }
}