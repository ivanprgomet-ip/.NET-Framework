using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Book:IComparable//Forces the class to use the CompareTo()
    {
        string ISBN;
        string title;
        string author;
        string price;

        public Book(string ISBN, string title, string author, string price)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public void Write()
        {
            Console.WriteLine($"author: {author} \n title: {title} \n price: {price} \n ISBN {ISBN}");
        }
        public int PriceForQuantity(int quantity)
        {
            return 0;
        }




        public int CompareTo(object o)
        {
            Book b = (Book)o;//convert the object to a book which we can actually use
            return this.ISBN.CompareTo(b.ISBN);
            //if(int.Parse(this.ISBN) > int.Parse(b.ISBN))
            //{
            //    return -1;//current instance is smaller
            //}
            //if (int.Parse(this.ISBN) < int.Parse(b.ISBN))
            //{
            //    return 1;//current instance is larger
            //}
            //else
            //    return 0;//current instances are equal
        }
        public override bool Equals(object o)
        {
            Book b = (Book)o;//overriding to make Equals relevant for Book objects
            return this.ISBN.Equals(b.ISBN);
        }
        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }
    }
}
