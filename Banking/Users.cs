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

namespace Banking
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void tbPrikazi_Click(object sender, EventArgs e)
        {
            var select = "SELECT * FROM Users";


            var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Id")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Clients WHERE Id LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "Name")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Users WHERE Name LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (comboBox1.Text == "User Name")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Users WHERE UserName LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "Cash AccountId")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Users WHERE UserName LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "Client Id")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Users WHERE ClientId LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            AddUser FM = new AddUser();
           
            FM.Show();
        }
    }
}
