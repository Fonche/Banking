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
    public partial class InsertClient : Form
    {
        public InsertClient()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                var c = new SqlConnection(Common.Common.connectionString);
                SqlCommand cmd = c.CreateCommand();
                cmd.CommandText = "Execute dbo.InsertClient   @Name,@Type,@IdentificationNumber,@Address,@Tel,@Mob,@Email,@Web";



                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBox1.Text.ToString();
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = textBox2.Text.ToString();
                cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar).Value = textBox3.Text.ToString();
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox4.Text.ToString();
                cmd.Parameters.Add("@Tel", SqlDbType.VarChar).Value = textBox5.Text.ToString();
                cmd.Parameters.Add("@Mob", SqlDbType.VarChar).Value = textBox6.Text.ToString();
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox7.Text.ToString();
                cmd.Parameters.Add("@Web", SqlDbType.VarChar).Value = textBox8.Text.ToString();

                c.Open();
                cmd.ExecuteNonQuery();
                c.Close();
              
                String mg = "Vnesovte nov Client";
                MessageBox.Show(mg);

            }
        }
    }
}
