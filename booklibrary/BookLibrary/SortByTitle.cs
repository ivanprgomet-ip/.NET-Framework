using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class SortByTitle : IComparer
    {
        public int Compare(object first, object second)
        {
            Book b1 = first as Book;
            Book b2 = second as Book;

            return b1.title.CompareTo(b2.title);
        }
    }
}
