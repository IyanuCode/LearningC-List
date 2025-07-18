using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LearningC_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Creating List
            List<int> numbers = new List<int>();
            List<string> country = new List<string>();
            List<double> money = new List<double>();

            //2. Creating List and initializing it with value
            List<string> fruits = new List<string>
        {
            "Apple", "Mango", "beatruit","Bananna","Water melon","Pineaple"
        };

            List<string> names = new List<string>
        {
            "David","Iyanu","Ohibor","Emmanuel","Buhari","Tinubu","Akeredolu","Aketi"
        };

            //3. Adding  items to the list 
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            numbers.Add(10); //the issue with this is that only i can't add multiple items, i can only add 1 item at once


            //4. adding multiple items
            country.AddRange(new List<string>
            {
                "Nigeria","Chana","Coutonu","Iraq"
            });

            money.AddRange(new List<double>{
                10.0, 11.50, 13.20, 14.30, 15.70
            });

            names.AddRange(new List<string>
            {
                "Ada","Ngozi","Chidinma","Chinozo"
             });

            //5. Inserting items
            names.Insert(1, "King"); // this will insert the item into index 1.

            //6. Remove item by value
            numbers.Remove(1);

            //7. Remove by index
            fruits.RemoveAt(1);


            //8. Removing All Matching a Condition either with A or a
            names.RemoveAll(f => f.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            //9. Checking Existence 
            bool hasIyanu = names.Contains("a");
            //Console.WriteLine(hasIyanu);//the issue with this is that if there is a name that contains the substring,though it's not what we are looking for, it will return true, this can be useful when we want to search for all possible value


            //10.Finding index
            int index = names.IndexOf("Iyanu");
            // Console.WriteLine($"The index of Iyanu in names is: {index}");

            //11. Accessing by Index(getting value by index)
            string firstName = names[0];
            // Console.WriteLine($"The first name in the List of names is: {firstName}");

            //12. Replacing item
            names[0] = "Kiwi";
            // Console.WriteLine($"am expecting 'kiwi' output because i just replace {names[0]}");

            //13. Clearing the list
            fruits.Clear();
            // Console.WriteLine($"Am expecting the output to be '0' because have cleared the list: {fruits.Count}");

            //14.Getting Count
            int moneyCount = money.Count();
            // Console.WriteLine($"Total number of items in money is: {moneyCount}");

            //15.Sorting Items
            names.Sort(StringComparer.OrdinalIgnoreCase); // I should bear in mind that if there is a word that starts with uppercase 'Z', it will be displayed before the word that starts with lowecase 'a' this is because C# displays uppercase first before lowercase so its better i convert everything to same case or i use ordinalIgnoreCase
            // Console.WriteLine("List of name in alphabetical order");

            // foreach (var name in names)
            // {
            //     Console.WriteLine(name);
            // }

            //16. Reversing items
            names.Reverse();
            Console.WriteLine("List of names when reversed");
            //foreach (var name in names)
            // {
            //     Console.WriteLine(name);
            // }

            //17.Finding
            // (returns only a value that mets the conditon)
            Console.WriteLine("using find");
            string? findingName = names.Find(f => f.StartsWith("k", StringComparison.OrdinalIgnoreCase));
            // Console.WriteLine(findingName + "\n");

            //Now finding all possible value that mets the condtion
            Console.WriteLine("Finding all possible value: ");
            List<string> FindAllItem = names.FindAll(f => f.StartsWith("c", StringComparison.OrdinalIgnoreCase));
            // foreach (var item in FindAllItem)
            // {
            //     Console.WriteLine(item);
            // }

            //18. Filtering using where
            var filtered = fruits.Where(f => f.Length > 2).ToList();
            Console.WriteLine($"filtering Fruit");
            // foreach (var fruit in filtered)
            // {
            //     Console.WriteLine(fruit);
            // }

            //19. sorting with OrderBy
            var moneyOrder = money.OrderBy(f => f).ToList();
            // Console.WriteLine("Using Order By ");
            // foreach (var eachMoney in moneyOrder)
            // {
            //     Console.WriteLine(eachMoney);
            // }

            //20. Aggregating 
            Console.WriteLine("\nAggregating values");
            List<int> allNums = new List<int> { 2, 4, 6, 8, 10 };
            // Console.WriteLine($"sum of all values in 'allNums' is: {allNums.Sum()}");
            // Console.WriteLine($"sum of all values in 'money' is: {money.Sum()}");


            //21. Any and All
            bool anyGreaterThanThree = money.Any(f => f > 3);// .Any returns only true or false
            bool allGreaterThanThree = money.All(f => f > 3);// .All checks true every and all value and returns true if all the value mets the condtion else returns fals


            //22. Combining List
            List<string> newFruts = fruits.Concat(new List<string> { "Lemon", "Melon", "Grape", "Melon", "Grape", "Cashew" }).ToList();
            Console.WriteLine("\nNew List for fruit");
            foreach (var item in newFruts)
            {
                Console.WriteLine(item);
            }

            //23. Distinct items
            var uniqueFruit = newFruts.Distinct().ToList(); //Distinct only takes one item out of many repeated items and this is what makes it distinct
            Console.WriteLine("\nUsing Distinct");
            foreach (var item in uniqueFruit)
            {
                Console.WriteLine(item);
            }

            //24. Coverting List to Array
            string[] nameArray = names.ToArray();
            Console.WriteLine("\n Converting name List to Array");
            foreach (var item in nameArray)
            {
                Console.WriteLine(item);
            }

            //25. Converting List to string
            string joinMoney = string.Join(",", money);
            Console.Write("\n Converting List to string \n" + joinMoney);

            //26. Filtering with predicate
            Console.WriteLine("\nPredicate");
            List<string> longNames = names.FindAll(t => t.Length > 5); //length is used with strings and in this case and mostly, it's used to get the number of character character in a word, whereas Count is used with List to get the total number of item
            foreach (var item in longNames)
            {
                Console.WriteLine(item);
            }

            //27. Duplicating or copying list
            //just as we have int num = 7 and we can also say int num2 = num. it's exactly as below
            List<string> nameBackup = new List<string>(names);

            //28.using Lambda( this is most useful when the code does just a single thing and no 27 can be re written as below:)
            Console.WriteLine("using Lambda");
            longNames.ForEach(f => Console.WriteLine(f));

            //List of Lists(i shoundn't forget that the second list is decalred inside the data type)
            List<List<int>> matrix = new List<List<int>> {
            new List<int> {1, 2},
            new List<int> {3, 4}
            };


            //29. Compare two list
            bool equal = fruits.SequenceEqual(names);

            //30, create sublist
            List<string> sub = names.GetRange(1, 2);//this line means start from the second line which is index 1 and pick the next 2 items

            //31. Find first or default
            string? result = fruits.FirstOrDefault(f => f.Contains("z")); // this line will look for the first item that matches the condition if there is none then it looks for anyone that have the condition which is the default, and if none value is found its return another default which null

            //32. Select 
            List<int> lengths = fruits.Select(s => s.Length).ToList();
            //this line means take each fruit converting it to list, store it back to length

            //33. sort by custom rule
            fruits.Sort((a, b) => b.Length.CompareTo(a.Length));

            //34. Max and Min value
            int maxLength = names.Max(f => f.Length);
            Console.WriteLine(maxLength);

            //35. Creating List from Enumberable
            List<int> enumNumbers = Enumerable.Range(1, 10).ToList();
            enumNumbers.ForEach(f => Console.WriteLine(f));

            //36. Skip and Take
            List<string> middle = fruits.Skip(1).Take(2).ToList();//instead of start from the first index which is 1, it skip it and start at the next take 2 means, take the next 2 item
            middle.ForEach(f => Console.WriteLine(f));

            //37. Check for duplicates
            bool hasDupes = names.Count != fruits.Distinct().Count();

            //38. Grouping items
            var groups = names.GroupBy(f => f.Length);
            foreach (var item in groups)
            {
                Console.WriteLine($"Length{item.Key}:{string.Join(",", item)}");
            }

            //39.Enumerable Repeat
            List<int> repeatedNumbers = Enumerable.Repeat(8, 5).ToList(); //this line means repeat the number 8 for 5 times and store it in a list
            Console.WriteLine("\nRepeating Enumberable Repeat");
            repeatedNumbers.ForEach(f => Console.WriteLine(f));

            //40. Find index by condition
            int indexByCondition = names.FindIndex(f => f.StartsWith("K", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nIndex of first name starting with 'K': {indexByCondition}");

            //41. Find last matching item
            string? lastMatchingName = names.FindLast(f => f.StartsWith("a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nLast name starting with 'a': {lastMatchingName}");

            //42. Find last index by condition
            int lastIndexByCondition = names.FindLastIndex(f => f.StartsWith("a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nLast index of name starting with 'a': {lastIndexByCondition}");

            //43. RemoveRange
            names.RemoveRange(0, 2); //this line means remove the first two items
            Console.WriteLine("\nAfter removing first two names:");
            names.ForEach(f => Console.WriteLine(f));

            //44. Binary Search
            names.Sort(); // Binary search requires the list to be sorted
            int binaryIndex = names.BinarySearch("Emmanuel", StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"\nBinary search index of 'Emmanuel': {binaryIndex}");

            //45. True for all check
            bool allStartsWithE = names.TrueForAll(f => f.StartsWith("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nAll names start with 'E': {allStartsWithE}");

            //46. Shuffle List
            Random rand = new Random();
            List<string> shuffledName = names.OrderBy(x => rand.Next()).ToList(); //this line means shuffle the names randomly
            Console.WriteLine("\nShuffled names:");
            shuffledName.ForEach(f => Console.WriteLine(f));

            //47. Remove All items that match a condition
            names.RemoveAll(f => f.Length < 5); //this line means remove all names  
            Console.WriteLine("\nAfter removing names shorter than 5 characters:");
            names.ForEach(f => Console.WriteLine(f));

            //48. Nested Object search
            fruits.RemoveAll(f => f.EndsWith("d", StringComparison.OrdinalIgnoreCase) || f.Length > 5); //this line means remove all fruits that ends with 'd' or 'D' or that the length is greater than 5
            Console.WriteLine("\nAfter removing fruits that end with 'd' or have length greater than 5:");
            fruits.ForEach(f => Console.WriteLine(f));

            //49. TakeWhile
            List<string> takeWhileNames = names.TakeWhile(f => f.Length < 6).ToList(); //this line means take all names that are less than 6 characters long until it finds one that is not
            Console.WriteLine("\nNames taken while length is less than 6:");
            takeWhileNames.ForEach(f => Console.WriteLine(f));

            //50. SkipWhile
            List<string> skipWhileNames = names.SkipWhile(f => f.Length < 6).ToList(); //this line means skip all names that are less than 6 characters long until it finds one that is not
            Console.WriteLine("\nNames skipped while length is less than 6:");
            skipWhileNames.ForEach(f => Console.WriteLine(f));

            //51. chunking list
            int chunkSize = 2;
            for (int i = 0; i < fruits.Count; i += chunkSize)
            {
                var chunk = fruits.Skip(i).Take(chunkSize).ToList();
                Console.WriteLine(string.Join(", ", chunk));
            }

            //52. Reverse in place
            fruits.Reverse(); //this line means reverse the order of the items in the list
            Console.WriteLine("\nReversed fruits:");
            fruits.ForEach(f => Console.WriteLine(f));

            //53. Query Syntax
            var querySyntax = from name in names
                              where name.Length > 5
                              orderby name
                              select name;
            Console.WriteLine("\nQuery Syntax for names longer than 5 characters:");
            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }

            //
            var adultNames = names.Where(p => p.Length > 5)
                                  .OrderBy(p => p)
                                    .Select(p => p);
            Console.WriteLine("\nQuery Syntax for names longer than 5 characters:");
            foreach (var item in adultNames)
            {
                Console.WriteLine(item);
            }

            //54. Deffered Execution
            var deferredQuery = names.Where(n => n.Length > 5); // this line means create a query that will only execute when we iterate over it, it does not execute immediately
            Console.WriteLine("\nDeferred Execution:");
            foreach (var item in deferredQuery)
            {
                Console.WriteLine(item);
            }

            //55. Immediate Execution
            var immediateQuery = names.Where(n => n.Length > 5).ToList(); // this line means create a query that will execute immediately and return a list
            Console.WriteLine("\nImmediate Execution:");
            immediateQuery.ForEach(f => Console.WriteLine(f));

            //56. Grouping by count
            var groupedByCount = names.GroupBy(n => n.Length)
                                      .Select(g => new { Length = g.Key, Count = g.Count() })
                                      .ToList();
            Console.WriteLine("\nGrouping by count:");
            groupedByCount.ForEach(g =>
            {
                Console.WriteLine($"Length: {g.Length}, Count: {g.Count}");
            });
            

            



          

            
























        }          
        }
    }

          