using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyDal_Lib
{
    public class DAL_Author
    {
        private SqlConnection _sqlConn = null;

        public void OpenConn(string connectionstring)
        {
            _sqlConn = new SqlConnection(connectionstring);
            _sqlConn.Open();
        }
        public void CloseConn()
        {
            _sqlConn.Close();
            _sqlConn.Dispose();
        }

        public void InsertAuthor(string firstname, string lastname)
        {
            string comm = $"Insert Into Authors(Firstname, Lastname) Values('{firstname}','{lastname}')";
            using (SqlCommand sqlComm = new SqlCommand(comm, _sqlConn))
            {
                sqlComm.ExecuteNonQuery();
            }
        }
        public void DeleteAuthor(int id)
        {
            string comm = $"DELETE FROM Authors WHERE AuthorID={id}";
            using (SqlCommand sqlComm = new SqlCommand(comm, _sqlConn))
            {
                sqlComm.ExecuteNonQuery();
            }
        }
        public void UpdateAuthorLastName(string lastName, int id)
        {
            string comm = $"UPDATE Authors SET Lastname = '{lastName}' WHERE AuthorID = {id}";

            using (SqlCommand sqlComm = new SqlCommand(comm, _sqlConn))
            {
                sqlComm.ExecuteNonQuery();
            }
        }

        public List<Author> GetAllAuthorsToList()
        {
            /*
                Extracts all the authors from the database 
                and puts them in a list of authors in csharp code. 
            */
            string comm = "SELECT * FROM Authors";
            List<Author> authorList = new List<Author>();

            using (SqlCommand sqlComm = new SqlCommand(comm,_sqlConn))
            {
                SqlDataReader reader = sqlComm.ExecuteReader();
                while (reader.Read())
                {
                    authorList.Add(new Author
                    {
                        AuthorID = (int)reader["AuthorID"],
                        Firstname = (string)reader["Firstname"],
                        Lastname =  (string)reader["Lastname"]
                    });
                }
            }
            return authorList;
        }
        public DataTable GetAllAuthorsToDataTable()
        {
            DataTable dataTable = new DataTable();
            string comm = "SELECT * FROM Authors";

            using(SqlCommand sqlComm = new SqlCommand(comm, _sqlConn))
            {
                /*
                    First we execute the command into the datareader, 
                    then we pass the reader object into the dataTable.
                */
                SqlDataReader reader = sqlComm.ExecuteReader();
                dataTable.Load(reader);
            }
            return dataTable;
        }
        public void DisplayConnectionState()
        {
            if (_sqlConn == null)
            {
                Console.WriteLine("Connection: Null");
            }
            else
            {
                if (_sqlConn.State == ConnectionState.Open)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Connection: Open");
                    Console.ResetColor();
                }
                else if (_sqlConn.State == ConnectionState.Closed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Connection: Closed");
                    Console.ResetColor();
                }
            }
            
        }
    }
}
