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
    public partial class TransEvidencija : Form
    {

        
        public long NalogodavacID { get; set; }
        public long PrimacID { get; set; }
        public string Status { get; set; }
        public decimal Balance { get; set; }
        public decimal Balance1 { get; set; }

        public string AccountNumber { get; set; }
        public static bool primac { get; set; }

        public long IdTransactions { get; set; }
        public decimal Amount { get; set; }
        public  int TransactionTypeId { get; set; }



        public TransEvidencija()
        {
            InitializeComponent();
            showAccounts();
        }

       



        public void VerifikacijaNalogodavac()
        {
         
            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Update Accounts SET Balance=(Balance-" + Amount + "), AmountOnHold = (AmountOnHold-" + Amount + ") where Id=" + NalogodavacID;
            c.Open();
            cmd.ExecuteNonQuery();
        }
        public void VerifikacijaPrimac()
        {
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand(" Update Accounts SET Balance = (Balance+" + Amount + ") where Id = " + PrimacID, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void VerifikacijaNalogodavac10()
        {
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand(" Update Accounts SET Balance = (Balance-" + Amount + "), AmountOnHold = (AmountOnHold-" + Amount + ") where Id=14", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void VerifikacijaPrimacPP10()
        {
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand(" Update Accounts SET Balance = (Balance+" + Amount + ") where Id = " + PrimacID, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void VerifikacijaNalogodavac40()
        {
            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Update Accounts SET Balance=(Balance+" + Amount + ") , AmountOnHold = (AmountOnHold-" + Amount + ") where Id=" + NalogodavacID;
            c.Open();
            cmd.ExecuteNonQuery();
        }
        public void VerifikacijaPrimacPP40()
        {
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand(" Update Accounts SET Balance = (Balance-" + Amount + ") where Id =14", conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void statusUpdate()
        {
            Console.WriteLine("Transaction ID: " + IdTransactions);
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd1 = new SqlCommand(" Update Transactions SET Status = 4  where Nacin=0 and Id=" + IdTransactions  , conn))

            {
                conn.Open();
                cmd1.ExecuteNonQuery();
            }
        }
        public void statusUpdate1()
        {
            Console.WriteLine("Transaction ID: " + IdTransactions);
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd1 = new SqlCommand(" Update Transactions SET Status = 2  where Nacin=1 and Id=" + IdTransactions, conn))

            {
                conn.Open();
                cmd1.ExecuteNonQuery();
            }
        }
        public void statusUpdate2()
        {
            Console.WriteLine("Transaction ID: " + IdTransactions);
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd1 = new SqlCommand(" Update Transactions SET Status = 3  where Nacin=2 and Id=" + IdTransactions, conn))

            {
                conn.Open();
                cmd1.ExecuteNonQuery();
            }
        }
        private void showAccounts()
        {
            var select = "SELECT * FROM Transactions where status=1 ";
            var c = new SqlConnection(Common.Common.connectionString); 
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (TransactionTypeId == 1)

            {

                VerifikacijaNalogodavac10();
                VerifikacijaPrimacPP10();
                statusUpdate();
                statusUpdate1();
                statusUpdate2();
                MessageBox.Show("Uspesna napravena veriikacija");
                showAccounts();

            }
            else
            {

                MessageBox.Show("Izbravte pogresna transakcija! Proverete Transaction Type Id za PP10 trea da bide 1");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            TransactionTypeId = Convert.ToInt16(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            if(TransactionTypeId==1)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button3.BackColor = Color.Red;
                button4.BackColor = Color.Red;
                button1.BackColor = Color.Green;
            }
            else if (TransactionTypeId == 2)
            {
                button1.Enabled = false;
                button4.Enabled = false;
                button1.BackColor = Color.Red;
                button4.BackColor = Color.Red;
                button3.BackColor = Color.Green;
            }
           else if (TransactionTypeId == 3)
            {
                button3.Enabled = false;
                button1.Enabled = false;
                button1.BackColor = Color.Red;
                button3.BackColor = Color.Red;
                button4.BackColor = Color.Green;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            Console.WriteLine("ROW INDEX: " + rowIndex + "data: " + dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
            IdTransactions = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
            Amount = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
            NalogodavacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
            PrimacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showAccounts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TransactionTypeId == 2)
            {
                VerifikacijaNalogodavac();
                VerifikacijaPrimac();
                statusUpdate();
                statusUpdate1();
                statusUpdate2();
                MessageBox.Show("Uspesna napravena veriikacija");
                showAccounts();
            }
            else
            {
                MessageBox.Show("Izbravte pogresna transakcija! Proverete Transaction Type Id za PP30 trea da bide 2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TransactionTypeId == 3)
            {
                VerifikacijaNalogodavac40();
                VerifikacijaPrimacPP40();
                statusUpdate();
                statusUpdate1();
                statusUpdate2();
                MessageBox.Show("Uspesna napravena veriikacija");
                showAccounts();
                button1.Enabled = false;
                button4.Enabled = false;

            }
            else
            {
                MessageBox.Show("Izbravte pogresna transakcija! Proverete Transaction Type Id za PP40 trea da bide 3");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
