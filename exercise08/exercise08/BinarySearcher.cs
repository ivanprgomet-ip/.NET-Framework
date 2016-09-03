using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    /// <summary>
    /// sort collections based on binary sort algorithm.
    /// EXERCISE 9
    /// </summary>
    class BinarySearcher
    {
        public void Search(int target, List<int> myCollection)
        {
            if(myCollection.BinarySearch(target)<0)
            {
                Console.WriteLine("The target " + target + " doesnt exist in the collection");
            }
            else
                Console.WriteLine("The target "+target+" is on index "+myCollection.BinarySearch(target)+" in the collection"); 
        }
    }
}
