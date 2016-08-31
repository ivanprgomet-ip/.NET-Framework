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

        public Library()
        {
            //DEFAULT BOOKS
            Book b1 = new Book(" 0143105426", "Pride and Prejudice", "Austen,Jane", 300);
            Book b2 = new Book(" 0465069347", "The Republic Of Plato", "Plato", 350);
            Book b3 = new Book(" 0226026752", "Aristotle's Nicomachean Ethics", "Aristotle", 300);
            Book b4 = new Book(" 0872202100", "Augustine: Political Writings", "Augustine", 300);
            Book b5 = new Book(" 0872206637", "On Law, Morality and Politics", "Aquinas, Thomas ", 300);
            Book b6 = new Book(" 0023513209", "Hegel: Reason in History", "G.W.F. Hegel", 300);
            Book b7 = new Book(" 0872202186", "Marx: Selected Writings", "Marx, Karl", 300);
            Book b8 = new Book(" 0446695890", "Admissions", "Lieberman, Nancy", 300);
            Book b9 = new Book(" 9780141018", "On the Shortness of Life", "Lucius Annaeus Seneca", 300);
            Book b10 = new Book("978067499", "Epistulae Morales: v. 1 Letters I-LXV", "Lucius Annaeus Seneca", 300);

            bookList.Add(b1);
            bookList.Add(b2);
            bookList.Add(b3);
            bookList.Add(b4);
            bookList.Add(b5);
            bookList.Add(b6);
            bookList.Add(b7);
            bookList.Add(b8);
            bookList.Add(b9);
            bookList.Add(b10);

            bookHash.Add("0143105426",b1);
            bookHash.Add("0465069347",b2);
            bookHash.Add("0226026752",b3);
            bookHash.Add("0872202100",b4);
            bookHash.Add("0872206637",b5);
            bookHash.Add("0023513209",b6);
            bookHash.Add("0872202186",b7);
            bookHash.Add("0446695890",b8);
            bookHash.Add("9780141018",b9);
            bookHash.Add("978067499",b10);
        }
        public void Main()
        {
            bool active = true;
            while (active)
            {
                Menu();
                choice = Console.ReadLine();

                switch (int.Parse(choice))
                {
                    case 1:
                        NewBook();
                        break;
                    case 2:
                        active = false;
                        Console.Clear();
                        Console.WriteLine("You have choosen to quit this application");
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

                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1. New Book");
            Console.WriteLine("2. Quit");
            Console.WriteLine("3. List all books");
            Console.WriteLine("4. Search book (arraylist)");
            Console.WriteLine("5. Sort books by ISBN");
            Console.WriteLine("6. Sort books by author");
            Console.WriteLine("7. List books (hashtable)");
            Console.WriteLine("8. Search Book (hashtable)");
        }

        public void NewBook()
        {
            Console.WriteLine("Enter book title: ");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter book author: ");
            string newAuthor = Console.ReadLine();

            Console.WriteLine("Enter book price: ");
            int newPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter book ISBN: ");
            string newISBN= Console.ReadLine();

            Book newBook = new Book(newISBN, newTitle, newAuthor, newPrice);
            bookList.Add(newBook);
            bookHash.Add(newISBN, newBook);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New book successfully added to book list and book hash!");
            Console.ResetColor();
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

            //TODO: what purpose does ICollection serve here?
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
            //TODO: what is the deal with the BookComparer class here?
            //var comparer = new BookComparator();
            //bookList.Sort(comparer);
            //Console.WriteLine("Books sorted by author name");
        }

    }

    //TODO: make a bookcomparer class that inherits from IComparer and has a compare method 
    //TODO: make book class inherit from IComparable, which means it will be forced to have a compareto method
    //TODO: add gethashcode and equals methods to the book class
}
