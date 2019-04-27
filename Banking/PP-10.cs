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
    public partial class PP_10 : Form
    {
        public long primacID{ get; set; }
        public string bankAccount = "1";
        public long bankId = 14;

        public const long TypeTransaction = 1;
  
        public string Status { get; set; }
        public bool Blocked { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal Amount { get; set; }
        public PP_10()


        {
            InitializeComponent();
        }

        private void PP_10_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSmetkaPrimac_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSmetkaPrimac_DoubleClick(object sender, EventArgs e)
        {
            pp1 FM = new pp1(this, "Primac");
            FM.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(textBox10.Text) > AvailableBalance || Status != "A" || Blocked)
            {
                MessageBox.Show("Ne moze da se izvrsi transakcija!");
                return;
            }
            addTransaction();
            AmountOnHoldNalogodavacPP10();
            MessageBox.Show("Uspesna napravena transakcija");
        }

        public void AmountOnHoldNalogodavacPP10()
        {

            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Update Accounts SET AmountOnHold=(AmountOnHold+" + Amount + ") where Id=14";
            c.Open();
            cmd.ExecuteNonQuery();
        }
        private void addTransaction()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
                using (SqlCommand cmd = new SqlCommand("InsertTransactions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionTypeId", TypeTransaction);
                    cmd.Parameters.AddWithValue("@UserId", Common.Common.currentUserId);
                    cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Currency", "MKD");
                    cmd.Parameters.AddWithValue("@AccoutIdDebit", bankId);
                    cmd.Parameters.AddWithValue("@AccoutIdCredit", primacID);
                    cmd.Parameters.AddWithValue("@Fee", 0);
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(textBox10.Text));
                    cmd.Parameters.AddWithValue("@Description", "");
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Nacin", Convert.ToInt16(tnNacin.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);


            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
           Amount= Convert.ToDecimal(textBox10.Text);
        }
    }
}
