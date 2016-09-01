using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /*
        This class serves as an external sort class
        for the book class. In the end we are comparing 
        the strings that are the book author names, and 
        as we all know, String class implements IComparable
        which makes this possible.
    */
    class SortByAuthor : IComparer
    {
        public int Compare(object first, object second)
        {
            Book b1 = (Book)first;
            Book b2 = (Book)second;

            string s1 = b1.author; /*+ b1.title; NOT NECCESSARY*/
            string s2 = b2.author; /*+ b2.title; NOT NECCESSARY*/

            return s1.CompareTo(s2);
        }
    }
}
