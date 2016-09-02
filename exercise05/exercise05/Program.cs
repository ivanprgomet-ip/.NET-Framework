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
            }

        }
    }
}
