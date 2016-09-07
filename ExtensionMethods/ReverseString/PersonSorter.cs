using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class PersonSorter : IComparer
    {
        public int Compare(object first, object second)
        {
            //sort by age
            Person p1 = (Person)first;
            Person p2 = (Person)second;


            return p1.Age.CompareTo(p2.Age);
        }
    }
}
