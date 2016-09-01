using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookComparer : IComparer
    {
        public int Compare(object first, object second)
        {
            Book b1 = (Book)first;
            Book b2 = (Book)second;

            string s1 = b1.author + b1.title;
            string s2 = b2.author + b2.title;

            return s1.CompareTo(s2);
        }
    }
}
