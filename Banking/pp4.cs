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
    public partial class pp4 : Form
    {
        public PP_40 PP40;
        public string who1;
        public decimal Amount { get; set; }
        public int prov = 20;

        public pp4(PP_40 pp40, string who1)
        {
            InitializeComponent();
            showAccounts();
            this.who1 = who1;
            PP40 = pp40;
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
                PP40.Controls["tbSmetka"].Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                PP40.primacID = Convert.ToInt64(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                getClients(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString());
                Amount = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[9].Value.ToString());
                PP40.Status = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                PP40.Blocked = Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells[6].Value);
                PP40.AvailableBalance = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells[10].Value.ToString());
                PP40.Controls["textBox11"].Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                PP40.Controls["prov"].Text = prov.ToString();
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
                            PP40.Controls["tbNalogodavac"].Text = rdr.GetString(0).ToString();
                            PP40.Controls["tbAddress"].Text = rdr.GetString(2).ToString();
                            PP40.Controls["tbEMBG"].Text = rdr.GetString(1).ToString();
                            PP40.Controls["tbNamePrimac"].Text = rdr.GetString(0).ToString();
                            PP40.Controls["tbAddressPrimac"].Text = rdr.GetString(2).ToString();
                        }

                    }
                }
            }

        }
    }
}
