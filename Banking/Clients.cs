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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
        

        }

        private void TbPrikazi_Click(object sender, EventArgs e)
        {
            var select = "SELECT * FROM Clients ";


            var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
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

            if (comboBox1.Text == "Id")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Clients WHERE Id LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            
            }
            if (comboBox1.Text == "Name")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Clients WHERE Name LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (comboBox1.Text == "Mob")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Clients WHERE Mob LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (comboBox1.Text == "Tel")
            {
                //var select = "SELECT * FROM Clients  where Id LIKE '"+textBox1.Text + "%'", c);


                var c = new SqlConnection(Common.Common.connectionString); // Your Connection String here
                var dataAdapter = new SqlDataAdapter("Select * From Clients WHERE Tel LIKE '" + textBox1.Text + "%'", c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
           
            
              
                cmd.CommandText = "Update Clients SET Name=@Name,Type=@Type,IdentificationNumber=@IdentificationNumber,Address=@Address,Tel=@Tel,Mob=@Mob,Email=@Email,Web=@Web where Id=@Id"  ;
          
            
                cmd.Parameters.AddWithValue("@Name",textBox9.Text);
                cmd.Parameters.AddWithValue("@Type",textBox2.Text);
                cmd.Parameters.AddWithValue("@IdentificationNumber",textBox3.Text);
                cmd.Parameters.AddWithValue("@Address",textBox4.Text);
                cmd.Parameters.AddWithValue("@Tel",textBox5.Text);
                cmd.Parameters.AddWithValue("@Mob",textBox6.Text);
                cmd.Parameters.AddWithValue("@Email",textBox7.Text);
                cmd.Parameters.AddWithValue("@Web",textBox8.Text);
            cmd.Parameters.AddWithValue("@Id", textBox10.Text);
                MessageBox.Show("Record Updated Successfully");

            c.Open();
            cmd.ExecuteNonQuery();
            c.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            var c = new SqlConnection(Common.Common.connectionString);
            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "Execute dbo.InsertClient   @Name,@Type,@IdentificationNumber,@Address,@Tel,@Mob,@Email,@Web";



            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBox9.Text.ToString();
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
