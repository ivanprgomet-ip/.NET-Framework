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
            DAL_Author dalAuthor = new DAL_Author();
            while (true)
            {
                Console.WriteLine("[1] Delete an Author");
                Console.WriteLine("[2] Print all Autors");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        dalAuthor.OpenConn(@"Data Source=.; Initial Catalog=Books; User ID=booksDB; Password=books; Integrated Security=True");
                        List<Author>AllAuthors = dalAuthor.GetAllAuthorsToList();
                        foreach(Author a in AllAuthors)
                        {
                            Console.WriteLine(a.Firstname+" "+a.Lastname);
                        }
                        dalAuthor.CloseConn();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
