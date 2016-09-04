using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise08
{
    /// <summary>
    /// exercise 11
    /// </summary>
    class ExchangeSorter
    {
        public void Swap(List<int> myCollection, int a, int b)
        {
            int r = myCollection[a];
            myCollection[a] = myCollection[b];
            myCollection[b] = r;
        }
        public void ExchangeSort(List<int> myCollection)
        {
            for (int i = 0; i < myCollection.Count-1; i++)
            {
                int least = i;
                for (int j = (i+1); j < myCollection.Count; j++)
                {
                    if(myCollection[least] > myCollection[j])
                    {
                        least = j;
                    }
                }
                if (i < least)
                {
                    Swap(myCollection, least, i);
                }
            }
        }
    }
}
