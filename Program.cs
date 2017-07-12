using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main()
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
            
            /* ======= Using Custom Types ======= */
            // Build a collection of customers who are millionaires
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            // ============== Final Version ================ 
            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */
            var grouped = customers.Where(c => c.Balance >= 1000000)
                .GroupBy(d => d.Bank);

            foreach (var item in grouped)
            {
                Console.WriteLine($"{item.Key} {item.Count()}");
                foreach (var customer in item)
                {
                    Console.WriteLine($"{customer.Name} {customer.Balance}");
                }
            }
            /*from customer in customers
            join bank in banks on customer equals bank.Symbol into bankName
            select new { bank = customer, b = bankName }; */

            var millionaireReport = from c in customers
                where c.Balance >= 1000000
                orderby c.Name[c.Name.IndexOf(" ") + 1] ascending
                join b in banks on c.Bank equals b.Symbol
                select new {Bank = b.Name, Name = c.Name};


            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }

        }
        // Define a bank
        public class Bank
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
        }

        // Define a customer
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
    }
}
