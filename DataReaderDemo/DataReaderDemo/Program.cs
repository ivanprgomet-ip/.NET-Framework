using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = string.Empty;

            while (true)
            {
                Console.WriteLine("[1] Print values in database");
                Console.WriteLine("[2] Add author to database");
                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        PrintDatabaseValues();
                        break;
                    case "2":
                        AddAuthor();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintDatabaseValues()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source=.; Initial Catalog=Books; User ID=booksDB; Password=books; Integrated Security=True";
                connection.Open();

                string sql = "SELECT * FROM Authors";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    ShowConnectionStatus(connection);
                    while (myDataReader.Read())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Fullname: " + myDataReader["Firstname"] + " " + myDataReader["Lastname"]);
                        Console.ResetColor();
                    }
                }
            }
        }

        private static void ShowConnectionStatus(SqlConnection connection)
        {
            Console.WriteLine("Database location: " + connection.DataSource);
            Console.WriteLine("Database name: " + connection.Database);
            Console.WriteLine("Timeut: " + connection.ConnectionTimeout);
            Console.WriteLine("State: " + connection.State);
        }

        static void AddAuthor()
        {
            Console.WriteLine("Enter authors firstname: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter authors lastname: ");
            string lastname = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source=.; Initial Catalog=Books; User ID=books; Password=books; Integrated Security=True";
                connection.Open();

                string sql =
                    "INSERT INTO Authors (firstname,lastname) VALUES('" + firstname + "','" + lastname + "')";
                SqlCommand insertCmd = new SqlCommand(sql, connection);

                if (insertCmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Authors table successfully updated");
                }
                else
                {
                    Console.WriteLine("Authors table not updated successfully");
                }
            }
        }
    }
}
