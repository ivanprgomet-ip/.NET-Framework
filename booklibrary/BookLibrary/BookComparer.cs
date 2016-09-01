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
        public int Compare(object x, object y)
        {
            Book b1 = (Book)x;
            Book b2 = (Book)y;

            throw new NotImplementedException();
        }
    }
}
