using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Library
    {
        string choice = string.Empty;

        static ArrayList bookList = new ArrayList();
        static Hashtable bookHash = new Hashtable();


        public static void Menu()
        {
            Console.WriteLine("1. New Book");
            Console.WriteLine("2.Quit");
            Console.WriteLine("3. List all books");
            Console.WriteLine("4. Search book (arraylist)");
            Console.WriteLine("5. Sort books by ISBN");
            Console.WriteLine("6. Sort books by author");
            Console.WriteLine("7. List books (hashtable)");
            Console.WriteLine("8. Search Book (hashtable)");
        }
        public void NewBook()
        {
            //enter all information neccessary for a new book
            Console.WriteLine("Enter book title: ");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter book author: ");
            string newAuthor = Console.ReadLine();

            Console.WriteLine("Enter book price: ");
            string newPrice = Console.ReadLine();

            Console.WriteLine("Enter book ISBN: ");
            string newISBN= Console.ReadLine();

            Book newBook = new Book(newISBN, newTitle, newAuthor, newPrice);
            bookList.Add(newBook);
            bookHash.Add(newISBN, newBook);

            Console.WriteLine("New book successfully added to book list and book hash!");
            Console.ReadKey();
        }
        public void ListList()
        {
            foreach(Book b in bookList)
            {
                b.Write();
            }
        }
        public static void ListHash()
        {
            ICollection e = bookHash.Values;
            foreach (Book b in bookHash)
            {
                b.Write();
            }
        }
        public static Book SearchList(string ISBN)
        {
            foreach(Book b in bookList)
            {
                if(b.ISBN.Equals(ISBN))
                {
                    return b;
                }
            }
            return null;
        }
        public static Book SearchHash(string ISBN)
        {
            foreach (Book b in bookHash)
            {
                if (b.ISBN.Equals(ISBN))
                {
                    return b;
                }
            }
            return null;
        }
        public static void SortListISBN()
        {
            bookList.Sort();
        }
        public static void SortListName()
        {
            //todo: fix this method!
            //var comparer = new BookComparator();
            //bookList.Sort(comparer);
            //Console.WriteLine("Books sorted by author name");
        }
        public void Main()
        {
            while (int.Parse(choice) != 2)
            {
                Menu();
                choice = Console.ReadLine();

                switch(int.Parse(choice))
                {
                    case 1:
                        NewBook();
                        break;
                    case 2:
                        //quits the application
                        break;
                    case 3:
                        ListList();
                        break;
                    case 4:
                        Console.WriteLine("Enter ISBN: ");
                        string ISBN = Console.ReadLine();

                        Book searched = SearchList(ISBN);

                        if (searched != null)
                        {
                            searched.Write();
                        }
                        else
                            Console.WriteLine("Sadly, the book was not found...");
                        break;
                    case 5:
                        SortListISBN();
                        break;
                    case 6:
                        SortListName();
                        break;
                    case 7:
                        ListHash();
                        break;
                    case 8:
                        Console.WriteLine("Enter ISBN: ");
                        string ISBN2 = Console.ReadLine();

                        Book searched2 = SearchHash(ISBN2);

                        if (searched2 != null)
                        {
                            searched2.Write();
                        }
                        else
                            Console.WriteLine("Sadly, the book was not found...");
                        break;
                }
            }
        }

    }
}
