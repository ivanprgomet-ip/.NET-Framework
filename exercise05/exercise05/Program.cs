using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise05
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            //store 1000 dice throws in a dictionary<index,throw>
            Random rnd = new Random();

            int throws = 1000;
            Dictionary<int, int> diceScores = new Dictionary<int, int>();

            //store index for dice throw and throw score
            for (int i = 0; i < throws; i++)
            {
                int currentThrow = rnd.Next(0, 7) + 1;
                diceScores.Add(i, currentThrow);
            }

            //print all scores
            foreach (KeyValuePair<int,int> kvp in diceScores)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                total += kvp.Value;//calculate total points of all throws
            }

            Console.WriteLine("The total of all throws: " + total);

            //calculate count on 1-7 scores
            Dictionary<string, int> orderedScores = new Dictionary<string, int>();

            //add default keys 1-7 with 0 as values. values gets added later
            for (int i = 1; i < 7; i++)
            {
                orderedScores.Add(i+"'s", 0);
            }

            //iterate over all 1000 throws and sort all scores into another dictionary
            foreach (KeyValuePair<int,int> kvp in diceScores)
            {
                //add +1 to X's value
                if (kvp.Value == 1)
                    orderedScores["1's"]++;
                if (kvp.Value == 2)
                    orderedScores["2's"]++;
                if (kvp.Value == 3)
                    orderedScores["3's"]++;
                if (kvp.Value == 4)
                    orderedScores["4's"]++;
                if (kvp.Value == 5)
                    orderedScores["5's"]++;
                if (kvp.Value == 6)
                    orderedScores["6's"]++;

            }

            //print scores ordered
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (KeyValuePair<string,int> kvp in orderedScores)
            {
                Console.WriteLine(kvp.Key+": "+kvp.Value+" times");
            }
            Console.ResetColor();



        }
    }
}
