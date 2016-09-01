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
        static ArrayList bookList = new ArrayList();
        static Hashtable bookHash = new Hashtable();

        //CONSTRUCTOR
        public Library()
        {
            //DEFAULT BOOKS
            Book b1 = new Book("0143105426", "Pride and Prejudice", "Austen,Jane", 300);
            Book b2 = new Book("0465069347", "The Republic Of Plato", "Plato", 350);
            Book b3 = new Book("0226026752", "Aristotle's Nicomachean Ethics", "Aristotle", 550);
            Book b4 = new Book("0872202100", "Augustine: Political Writings", "Augustine", 550);
            Book b5 = new Book("0872206637", "On Law, Morality and Politics", "Aquinas, Thomas ", 300);
            Book b6 = new Book("0023513209", "Hegel: Reason in History", "G.W.F. Hegel", 300);
            Book b7 = new Book("0872202186", "Marx: Selected Writings", "Marx, Karl", 690);
            Book b8 = new Book("0446695890", "Admissions", "Lieberman, Nancy", 300);
            Book b9 = new Book("9780141018", "On the Shortness of Life", "Lucius Annaeus Seneca", 70);
            Book b10 = new Book("978067499", "Epistulae Morales: v. 1 Letters I-LXV", "Lucius Annaeus Seneca", 200);

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

        //METHODS
        public void Main()
        {
            bool active = true;
            string choice = string.Empty;

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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have choosen to quit this application...");
                        Console.ResetColor();
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
                    case 66:
                        SortListPrice();
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
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Quit");
            Console.WriteLine("---------------");
            Console.WriteLine("3. List books (ArrayList)");
            Console.WriteLine("4. Search book (ArrayList)");
            Console.WriteLine("5. Sort books by ISBN (ArrayList)");
            Console.WriteLine("6. Sort books by Author (ArrayList)");
            Console.WriteLine("66. Sort books by Price (ArrayList)");
            Console.WriteLine("---------------");
            Console.WriteLine("7. List books (HashTable)");
            Console.WriteLine("8. Search Book (HashTable)");

            Console.WriteLine();
            Console.Write(">> ");
        }

        public static void NewBook()
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
            Console.WriteLine("New book successfully added to both list types!");
            Console.ResetColor();
        }
        public static void ListList()
        {
            Console.WriteLine("________________________________________________________________________");
            foreach (Book b in bookList)
            {
                b.Write();
                Console.WriteLine("________________________________________________________________________");
            }
        }
        public static void ListHash()
        {
            //retrieve all values from HashTable and store in ICollection:
            ICollection e = bookHash.Values;
            //iterate over ICollection like you would with a List:
            Console.WriteLine("________________________________________________________________________");
            foreach (Book b in e)
            {
                b.Write();
                Console.WriteLine("________________________________________________________________________");
            }
        }
        public static Book SearchList(string ISBN)
        {
            foreach (Book b in bookList)
            {
                if (b.ISBN.Equals(ISBN))
                {
                    return b;
                }
            }
            return null;
        }
        public static Book SearchHash(string ISBN)
        {
            //returns a book if the ISBN matches any existing
            //books ISBN, else returns NULL.
            return (Book)bookHash[ISBN];
        }
        public static void SortListISBN()
        {
            //USING THE DEFAULT INTERNAL SORT METHOD FOR BOOK CLASS (COMPARETO)
            bookList.Sort();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Books sorted by ISBN (internally using compareto)");
            Console.ResetColor();

        }
        public static void SortListName()
        {
            //USING AN EXTERNAL SORT CLASS WHICH IMPLEMENTS ICOMPARER
            bookList.Sort(new SortByAuthor());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Books sorted by author (using external sort class)");
            Console.ResetColor();
        }
        private void SortListPrice()
        {
            bookList.Sort(new SortByPrice());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Books sorted by price (using external sort class)");
            Console.ResetColor();
        }

    }
}
