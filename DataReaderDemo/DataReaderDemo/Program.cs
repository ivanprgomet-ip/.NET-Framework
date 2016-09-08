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
                Console.WriteLine("[3] Remove an author from database");
                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        PrintDatabaseValues();
                        break;
                    case "2":
                        AddAuthor();
                        break;
                    case "3":
                        RemoveAuthorWithID();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintDatabaseValues()
        {
            /*
                A SqlConnection object that will have a property connectionstring
                that will be of vital importance to connect and communicate with a
                database. The connection has to be opened between the c# platform and 
                the sql database to make sure they can communicate. A SQL command is 
                created and stored in a string (you can first do the sqlcommand in SQL 
                server to make sure the command really works. After storing the sql command
                in a string, the string gets passed into an instantiated SqlCommand object together
                with the SqlConnection object. then we use the SqlCommand togeter with an SqlDatareader
                object becuase we want to read the command. so the datareader recieves all values that get 
                retrieved when executing a command (SqlCommand).

            */
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
                        Console.WriteLine(myDataReader["Id"]+": " + myDataReader["Firstname"] + " " + myDataReader["Lastname"]);
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
        static void RemoveAuthorWithID()
        {
            Console.WriteLine("Enter ID of the author to remove: ");
            string deleteID = Console.ReadLine();

            string connectionstring = @"Data Source=.; Initial Catalog=Books; User ID=books; Password=books; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            string sqlComm = "delete from Authors where Id = " + deleteID;
            SqlCommand comm = new SqlCommand(sqlComm,conn);


            Console.WriteLine($"{comm.ExecuteNonQuery()} rows affected");
            Console.ReadKey();
            conn.Close();
        }
    }
}
