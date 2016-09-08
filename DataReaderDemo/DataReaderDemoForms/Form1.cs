using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataReaderDemoForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.Authors' table. You can move, or remove it, as needed.
            this.authorsTableAdapter.Fill(this.booksDataSet.Authors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Enter authors firstname: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter authors lastname: ");
            string lastname = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection())//instantiates and closes connection when leaves using scope
            {
                connection.ConnectionString = @"Data Source=.; Initial Catalog=Books; User ID=books; Password=books; Integrated Security=True";
                connection.Open();

                string sql = "INSERT INTO Authors (firstname,lastname) VALUES('" + txt_firstname.Text+ "','" + txt_lastname.Text+ "')";
                SqlCommand insertCmd = new SqlCommand(sql, connection);

                if (insertCmd.ExecuteNonQuery() > 0)
                {
                    lbl_result.Text ="Authors table successfully updated";
                }
                else
                {
                    lbl_result.Text = "Authors table not updated successfully";
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.authorsTableAdapter.Fill(this.booksDataSet.Authors);
        }
    }
}
