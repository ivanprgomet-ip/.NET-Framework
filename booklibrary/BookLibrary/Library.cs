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

        }
        public void Listlist()
        {

        }
        public void ListHash()
        {

        }
        public Book SearchList(string ISBN)
        {
            return new Book();
        }
        public Book SearchHash(string ISBN)
        {
            return new Book();
        }
        public void SortListISBN()
        {

        }
        public void SortListName()
        {

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
                        //new book
                        break;
                    case 2:
                        //quit
                        break;
                    case 3:
                        //list all books
                        break;
                    case 4:
                        //search book arraylist
                        break;
                    case 5:
                        //sort books by isbn
                        break;
                    case 6:
                        //sort books by author
                        break;
                    case 7:
                        //list books hashtable
                        break;
                    case 8:
                        //search book hashtable
                        break;
                }
            }
        }

    }
}
