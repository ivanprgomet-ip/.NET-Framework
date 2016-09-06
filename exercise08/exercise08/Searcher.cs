using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    class Searcher
    {
        public void BruteForceSearchHard(int target, List<int> myCollection)
        {
            int counter = 0;
            foreach (int num in myCollection)
            {
                if (target.Equals(num))
                    counter++;
            }

            if (counter > 0)
                Console.WriteLine($"{counter} instances of the target {target} was found in the collection");
            else
                Console.WriteLine($"No instances of {target} was found in the collection");
        }
        public void BinarySearch(int target, List<int> myCollection)
        {
            if (myCollection.BinarySearch(target) < 0)
            {
                Console.WriteLine("The target " + target + " doesnt exist in the collection");
            }
            else
                Console.WriteLine("The target " + target + " is on index " + myCollection.BinarySearch(target) + " in the collection");
        }

        public void BruteForceSearchSoft(List<int> toBeSearched, int searchTarget)
        {
            bool containsTarget = false;
            int index = 0;
            Console.WriteLine("----------------------");

            foreach (int i in toBeSearched)
            {
                
                if (i.ToString().Contains(searchTarget.ToString()))
                {
                    Console.WriteLine(index + ": " + i);
                    containsTarget = true;
                }
                index++;
            }

            Console.WriteLine(containsTarget ? "Searchtarget(s) found" : "No Searchtarget(s) found");
        }
    }
}
