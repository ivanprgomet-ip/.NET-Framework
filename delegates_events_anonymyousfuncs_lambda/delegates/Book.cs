using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    public struct Book
    {
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;

        public Book(string title, string author, decimal price, bool paperback)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
            this.Paperback = paperback;
        }

    }

    public delegate void ProcessBookDelegate(Book book);//METODER SOM TAR EMOT BOK SOM INPARAMETER OCH RETURNERAR VOID

    public class BookDB
    {
        ArrayList list = new ArrayList();
        public void AddBook(string title, string author, decimal price, bool paperback)
        {
            list.Add(new Book(title, author, price, paperback));
        }
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)//taking in delegate
        {
            foreach (Book b in list)
            {
                if (b.Paperback)
                {
                    processBook(b);//the delegate itself takes in a book
                }
            }
        }
    }
}

namespace BookTestClient
{
    using delegates;

    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0M;//M=we are working with Money

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }
        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    class Test
    {
        static void PrintTitle(Book b)
        {
            Console.WriteLine("{0}", b.Title);
        }
        static void Main()
        {
            BookDB bookDB = new BookDB();
            AddBooks(bookDB);
            Console.WriteLine("paperback book titles: ");

            Console.WriteLine("DELEGATE CALL 1");
            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));//METODER SOM TAR EMOT BOK SOM INPARAMETER OCH RETURNERAR VOID

            PriceTotaller totaller = new PriceTotaller();
            Console.WriteLine("DELEGATE CALL 2");
            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(totaller.AddBookToTotal));//inserting pricetotaller object into delegate that only takes book? //METODER SOM TAR EMOT BOK SOM INPARAMETER OCH RETURNERAR VOID
            Console.WriteLine("Average paperback book price ${0:#.##}", totaller.AveragePrice());
            Console.ReadKey();


            //random test
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("_________________________");
            TextAdderToBook adder = new TextAdderToBook();
            bookDB.ProcessPaperbackBooks(adder.AddTextToBookTitle);
            Console.ResetColor();
            
        }

        private static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Lanugage", "Brian W. Kernigham and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("Default book title 1", "Default author(s) 1", 22.95m, true);
            bookDB.AddBook("Default book title 2", "Default author(s) 2", 99.95m, false);
            bookDB.AddBook("Default book title 3", "Default author(s) 3", 35.95m, true);
        }
    }

    class TextAdderToBook//random test
    {
        public void AddTextToBookTitle(Book book)
        {
            Console.WriteLine(book.Title + " is a cool book!");
        }
    }
}
