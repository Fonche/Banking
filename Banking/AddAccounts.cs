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
    public partial class AddAccounts : Form
    {
        public AddAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addAccounts(tbTypeId.Text, tbAccountNumber.Text, tbCurrency.Text, tbClientId.Text, comboBox1.Text, comboBox2.Text, tbOverdraftLimit.Text, tbAmountOnHold.Text);
            MessageBox.Show("Uspesno vnesove Account");
           
        }

        public static void addAccounts(string TypeIdr, string AccountNumber, string Currency, string ClientId, string Status, string Balance, string OverdraftLimit, string AmountOnHold)
        {
            try
            {
                var c = new SqlConnection(Common.Common.connectionString);
                using (SqlConnection conn = new SqlConnection(Common.Common.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.InsertAccount", conn))
                    {



                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TypeId", TypeIdr);
                        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        cmd.Parameters.AddWithValue("@Currency", Currency);
                        cmd.Parameters.AddWithValue("@ClientId", ClientId);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Blocked", Balance);
                        cmd.Parameters.AddWithValue("@Balance", OverdraftLimit);
                        cmd.Parameters.AddWithValue("@OverdraftLimit", OverdraftLimit);
                        cmd.Parameters.AddWithValue("@AmountOnHold", AmountOnHold);





                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                    }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.Message);

            }
        
        }
    }
}
