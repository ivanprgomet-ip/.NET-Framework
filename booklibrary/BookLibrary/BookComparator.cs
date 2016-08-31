using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class BookComparator:IComparer
    {
        public int Compare(object x, object y)
        {
            var bookOne = (Book)x;
            var bookTwo = (Book)y;

            var first = $"{bookOne.author} {bookOne.title}";
            var second = $"{bookTwo.author} {bookTwo.title}";

            return string.Compare(first, second);
        }
    }
}
