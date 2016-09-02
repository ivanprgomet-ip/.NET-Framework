using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    //EXERCISE 8
    class BruteForcer
    {
        /// <summary>
        /// Takes in a target int and a collection. The collection
        /// will be searched for the target entered. All instances found
        /// will be counted and later printed out. 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="myCollection"></param>
        public void Search(int target, List<int> myCollection)
        {
            int counter = 0;
            foreach(int num in myCollection)
            {
                if (target.Equals(num))
                    counter++;
            }

            if (counter > 0)
                Console.WriteLine($"{counter} instances of the target {target} was found in the collection");
            else
                Console.WriteLine($"No instances of {target} was found in the collection");
        }
    }
}
