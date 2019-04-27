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
    public partial class Accounts : Form
    {
        public PP_30 PP30;
        public string who;
        public int prov =20;
        
        public Accounts()
        {
            InitializeComponent();
            showAccounts();
        }

        public Accounts(PP_30 pp30, string who)
        {
            InitializeComponent();
            showAccounts();
            this.who = who;
            PP30 = pp30;
        }

        private void showAccounts()
        {
            var select = "SELECT * FROM Accounts ";
            var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (who.Equals("nalogodavac"))
            {
                PP30.Controls["tbSmetkaNaNalogodavac"].Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                PP30.NalogodavacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                PP30.Controls["textBox11"].Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
            }
            else
            {
                PP30.Controls["tbSmetkaPrimac"].Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                PP30.PrimacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());

            }
            PP30.Status = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            PP30.Blocked = Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells[6].Value);
            PP30.AvailableBalance = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());
            PP30.Controls["prov"].Text = prov.ToString();
            PP30.AmountOnHold = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
            PP30.IdTransactions = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
            getClients(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
            
            this.Close();
        }

        private void getClients(string id)
        {
            
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "Select Name,Address from Clients where Id=" + id;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (who.Equals("nalogodavac"))
                        {   

                            PP30.Controls["tbName"].Text = rdr.GetString(0).ToString();
                            PP30.Controls["tbAddress"].Text = rdr.GetString(1).ToString();
                        }
                        else
                        {
                            PP30.Controls["tbNamePrimac"].Text = rdr.GetString(0).ToString();
                            PP30.Controls["tbAddressaPrimac"].Text = rdr.GetString(1).ToString();
                        }
                    }
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAccounts a = new AddAccounts();
            a.Show();
        }
    }
}
