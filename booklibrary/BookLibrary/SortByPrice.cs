using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class SortByPrice : IComparer
    {
        public int Compare(object first, object second)
        {
            Book b1 = (Book)first;
            Book b2 = (Book)second;

            //both returns will work when sorting by price

            //return b1.price - b2.price;
            return b1.price.CompareTo(b2.price);
        }
    }
}
