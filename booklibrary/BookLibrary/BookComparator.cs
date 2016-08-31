using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    interface BookComparator:IComparer
    {
        public int Compare(object o1, object o2)
        {
            Book b1 = o1 as Book;
            //not finnished
        }
    }
}
