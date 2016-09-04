using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            Searcher se = new Searcher();

            //EXERCISE 8
            Console.WriteLine("EXERCISE 08 | BRUTE FORCE SEARCH");
            List<int> myCollection = new List<int>();//instantiate an empty list
            PopulateCollection(myCollection);//fill the list with dummy values (0-1000)
            se.BruteForceSearch(849, myCollection);//search inputted list for specific value
            Console.WriteLine("------------");
            //EXERCISE 9
            Console.WriteLine("EXERCISE 09 | BINARYSEARCH");
            List<int> myCollection2 = new List<int>();
            PopulateCollection(myCollection2);
            myCollection2.Sort();//neccessary for binarysearch to work propperly
            PrintList(myCollection2);
            se.BruteForceSearch(500, myCollection2);
            Console.WriteLine("------------");



            Sorter s = new Sorter();

            //EXERCISE 10
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("EXERCISE 10 | BUBBLESORT");
            List<int> myCollection3 = new List<int>();
            PopulateCollection(myCollection3);
            s.BubbleSort(myCollection3);
            PrintList(myCollection3);
            Console.WriteLine("------------");
            Console.ResetColor();
            //EXERCISE 11
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EXERCISE 10 | EXCHANGE SORT");
            List<int> myCollection4 = new List<int>();
            PopulateCollection(myCollection4);
            s.ExchangeSort(myCollection4);
            PrintList(myCollection4);
            Console.WriteLine("------------");
            Console.ResetColor();
        }

        public static void PopulateCollection(List<int> myCollection)
        {
            //foundation for searching or sorting on
            Random rnd = new Random();
            for (int i = 0; i < 200; i++)
            {
                int number = rnd.Next(1, 1000);
                while (myCollection.Contains(number))
                {
                    number = rnd.Next(1, 1000);
                }
                myCollection.Add(number);
            }
        }
        public static void PrintList(List<int> myCollection)
        {
            for (int i = 0; i < myCollection.Count; i++)
            {
                Console.WriteLine(i + ": " + myCollection[i]);
            }
            //foreach (int num in myCollection)
            //{
            //    Console.WriteLine(num);
            //}
        }
    }
}
