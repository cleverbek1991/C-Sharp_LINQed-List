using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ======= Restriction/Filtering Operations ======= */
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
            var LFruits = 
            from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;
            foreach (var fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>(){15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};
            var fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);
            foreach(var n in fourSixMultiples)
            {
                Console.WriteLine(n);
            }
            /* ======= Ordering Operations ======= */
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = names.OrderByDescending(a => a);
            foreach(var n in descend)
            {
                Console.WriteLine(n);
            }
            // Build a collection of these numbers sorted in ascending order
            var numDescend = numbers.OrderBy(n => n);
            foreach(var num in numDescend)
            {
                Console.WriteLine(num);
            }
            /* ======= Aggregate Operations ======= */
            // Output how many numbers are in this list
            Console.WriteLine(numbers.Count() + " numbers are in this list");
            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine("We Have Made $" + purchases.Sum());
            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine("The most Expensive product price is $" + prices.Max());
            /* ======= Partitioning Operations ======= */
            /*
            Store each number in the following List until a perfect square
            is detected.
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            var perfectSqrt = wheresSquaredo.TakeWhile(s => s % Math.Sqrt(s) != 0);
            foreach(var s in perfectSqrt)
            {
                Console.WriteLine(s);
            }
        }
    }
}
