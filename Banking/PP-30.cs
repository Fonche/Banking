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

    public partial class PP_30 : Form
    {
        public const long TypeTransaction = 2;
        public long NalogodavacID { get; set; }
        public long PrimacID { get; set; }
        public string Status { get; set; }
        public bool Blocked { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal Balance { get; set; }
        public decimal Balance1 { get; set; }

        public string AccountNumber { get; set; }
        public static bool primac { get; set; }

        public long IdTransactions { get; set; }

        public decimal Amount { get; set; }
        public decimal AmountOnHold { get; set; }


        public PP_30()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(tbAmount.Text) > AvailableBalance || Status != "A" || Blocked)
            {
                MessageBox.Show("Ne moze da se izvrsi transakcija!");
                return;
            }

          
            addTransaction();
            AmountOnHoldNalogodavacPP30();
            //AmountOnHoldPrimacPP30();
            MessageBox.Show("Uspesna napravena transakcija");
         
            
       




        }

        public void AmountOnHoldNalogodavacPP30()
        {

            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Update Accounts SET AmountOnHold=(AmountOnHold+" + Amount + ") where Id=" + NalogodavacID;
            c.Open();
            cmd.ExecuteNonQuery();
        }
      /* public void AmountOnHoldPrimacPP30()
        {
            using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
            using (SqlCommand cmd = new SqlCommand(" Update Accounts SET AmountOnHold = (AmountOnHold+" + Amount + ") where Id = " + PrimacID, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }*/
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
                    cmd.Parameters.AddWithValue("@AccoutIdCredit", PrimacID);
                    cmd.Parameters.AddWithValue("@Fee", 0);
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(tbAmount.Text));
                    cmd.Parameters.AddWithValue("@Description", richTextBox1.Text);
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

        
        private void PP_30_Load(object sender, EventArgs e)
        {
           
        }

        private void tbSmetkaNaNalogodavac_DoubleClick(object sender, EventArgs e)
        {
            Accounts a = new Accounts(this,"nalogodavac");
            a.Show();
        }

        private void tbSmetkaPrimac_DoubleClick(object sender, EventArgs e)
        {
            Accounts a = new Accounts(this, "primac");
            a.Show();
        }

        private void tbSmetkaPrimac_TextChanged(object sender, EventArgs e)
        {

        }

        private void tnNacin_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbAmount_Leave(object sender, EventArgs e)
        {
            Amount = Convert.ToDecimal(tbAmount.Text);
        }

        private void tbSmetkaNaNalogodavac_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNamePrimac_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
