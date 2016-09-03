using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    /// <summary>
    /// EXERCISE 10
    /// </summary>
    class BubbleSorter
    {

        public void BubbleSort(List<int> myCollection)
        {
            bool unsorted = true;
            int end = myCollection.Count-1;

            while (unsorted)
            {
                unsorted = false;
                for (int i = 0; i < end; i++)
                {
                    if(myCollection[i] > myCollection[i+1])
                    {
                        Swap(myCollection, i, i + 1);
                        unsorted = true;
                    }
                }
                end--;
            }
        }
        public void Swap(List<int> myCollection, int a, int b)
        {
            int r = myCollection[a];
            myCollection[a] = myCollection[b];
            myCollection[b] = r;
        }

    }
}
