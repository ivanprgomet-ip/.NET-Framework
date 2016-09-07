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

        public void BinarySearch(int target, List<int> myCollection)
        {
            //keep in mind the collection is sorted!
            int high = myCollection.Count;
            int low = 0;
            int mid;

            while (high - low > 1)//while we have at least one point to compare with
            {
                mid = (high + low) / 2;//find the middle index
                if (myCollection[mid] > target)
                {
                    high = mid; //cutting the collection by placing new highest index
                }
                else
                {
                    low = mid; //cutting the collection by placing new lowest index
                }
            }

            if (low == -1 || myCollection[low] != target)
            {
                Console.WriteLine("Target not found in collection");
            }
            else
            {
                Console.WriteLine($"{target} found on index {low}");
            }
        }

    }
}
