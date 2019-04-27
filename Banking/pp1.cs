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
    public partial class pp1 : Form
    {
        public PP_10 PP10;
        public string who1;
        public int prov = 25;
        public decimal Amount { get; set; }

        public pp1(PP_10 pp10 ,string who1)
        {
            InitializeComponent();
            showAccounts();
            this.who1 = who1;
            PP10 = pp10;
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
            if (who1.Equals("Primac"))
            {
                PP10.Controls["tbSmetkaPrimac"].Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                PP10.primacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                getClients(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
                Amount = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
                PP10.Controls["prov"].Text =prov.ToString();
                PP10.Status = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                PP10.Blocked = Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells[6].Value);
                PP10.AvailableBalance = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());
                getClients(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
                this.Close();
            }


        }
            private void getClients(string id)
            {

                using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Select Name,IdentificationNumber,Address from Clients where Id=" + id;
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (who1.Equals("Primac"))
                            {
                                PP10.Controls["tbNamePrimac"].Text = rdr.GetString(0).ToString();
                                PP10.Controls["tbAddressaPrimac"].Text = rdr.GetString(2).ToString();
                                PP10.Controls["tbEMBG"].Text = rdr.GetString(1).ToString();
                            PP10.Controls["tbName"].Text = rdr.GetString(0).ToString();
                            PP10.Controls["tbAddress"].Text = rdr.GetString(2).ToString();
                        }
                          
                        }
                    }
                }

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
