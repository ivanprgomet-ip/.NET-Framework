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
            BruteForcer searcher = new BruteForcer();//instantiate a searcher
            List<int> myCollection = new List<int>();//instantiate an empty list
            FillCollection(myCollection);//fill the list with dummy values (0-1000)
            searcher.BruteForce(849, myCollection);//search inputted list for specific value
        }

        public static void FillCollection(List<int> myCollection)
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
            foreach (int num in myCollection)
            {
                Console.WriteLine(num);
            }
        }
    }
}
