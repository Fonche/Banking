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
    public partial class PP_40 : Form
    {
        public long primacID { get; set; }
        public string bankAccount = "1";
        public long bankId = 14;


        public const long TypeTransaction =3;

        public string Status { get; set; }
        public bool Blocked { get; set; }
        public decimal AvailableBalance { get; set; }

        public decimal Balanc { get; set; }
        public decimal Amount { get; set; }
        public long NalogodavacID { get; set; }

        public PP_40()
        {
            InitializeComponent();
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
                    cmd.Parameters.AddWithValue("@AccoutIdDebit", NalogodavacID);
                    cmd.Parameters.AddWithValue("@AccoutIdCredit", bankId);
                    cmd.Parameters.AddWithValue("@Fee", 0);
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(tbAmount.Text));
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
        public void AmountOnHoldNalogodavacPP40()
        {

            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Update Accounts SET AmountOnHold=(AmountOnHold+" + Amount + ") where Id=" + NalogodavacID;
            c.Open();
            cmd.ExecuteNonQuery();
        }
        private void tbSmetka_DoubleClick(object sender, EventArgs e)
        {
            pp4 FM = new pp4(this, "Primac");
            FM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(tbAmount.Text) > AvailableBalance || Status != "A" || Blocked)
            {
                MessageBox.Show("Ne moze da se izvrsi transakcija!");
                return;
            }
            addTransaction();
            AmountOnHoldNalogodavacPP40();
            MessageBox.Show("Uspesna napravena transakcija");
        }

        private void tbAmount_Leave(object sender, EventArgs e)
        {
            Amount = Convert.ToDecimal(tbAmount.Text);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
