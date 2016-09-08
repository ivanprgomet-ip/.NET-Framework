using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDal_Lib;




namespace MyDal_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = @"Data Source=.; Initial Catalog=Books; User ID=booksDB; Password=books; Integrated Security=True";
            DAL_Author dalAuthor = new DAL_Author();
            while (true)
            {
                dalAuthor.DisplayConnectionState();
                Console.WriteLine("[1] Add an author");
                Console.WriteLine("[2] Delete an Author");
                Console.WriteLine("[3] Update/change an authors lastname");
                Console.WriteLine("[4] Print all Autors");
                string choice = Console.ReadLine();
                

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter firstname of Author to insert: ");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Enter lastname of Author to insert: ");
                        string lastname = Console.ReadLine();
                        dalAuthor.OpenConn(connectionstring);//OPEN CONNECTION
                        dalAuthor.InsertAuthor(firstname, lastname);
                        dalAuthor.CloseConn();//CLOSE CONNECTION
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Which Author to delete? ID >> ");
                        int id = int.Parse(Console.ReadLine());
                        dalAuthor.OpenConn(connectionstring);//OPEN CONNECTION
                        dalAuthor.DeleteAuthor(id);
                        dalAuthor.CloseConn();//CLOSE CONNECTION
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Which Authors Lastname to change? ID >> ");
                        int newLastnameID  = int.Parse(Console.ReadLine());
                        Console.WriteLine("New Lastname >> ");
                        string newLastname = Console.ReadLine();
                        dalAuthor.OpenConn(connectionstring);
                        dalAuthor.UpdateAuthorLastName(newLastname, newLastnameID);
                        dalAuthor.CloseConn();
                        break;
                    case "4":
                        dalAuthor.OpenConn(connectionstring);
                        List<Author> AllAuthors = dalAuthor.GetAllAuthorsToList();
                        foreach (Author a in AllAuthors)
                        {
                            Console.WriteLine(a.AuthorID + ": " + a.Firstname + " " + a.Lastname);
                        }
                        dalAuthor.CloseConn();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();

            }
        }
    }
}
