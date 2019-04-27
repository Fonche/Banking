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
    public partial class TransFinal : Form
    {
        public TransFinal()
        {
            InitializeComponent();
            showAccounts();
        }

        private void showAccounts()
        {
            var select = "SELECT * FROM Transactions WHERE Status=4";
            var c = new SqlConnection(Common.Common.connectionString);
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Data")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE Date LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "UserId")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE UserId LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "Amount")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE Amount LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "AccountId Debit")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE AccountIdDebit LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "AccountId Credit")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE AccountIdCredit LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
            if (comboBox1.Text == "Transaction TypeId")
            {



                var c = new SqlConnection(Common.Common.connectionString);
                var dataAdapter = new SqlDataAdapter("Select * From Transactions WHERE TransactionTypeId LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];

            }
        }
    }
}
