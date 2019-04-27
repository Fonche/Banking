using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Security.Cryptography;
using System.Configuration;



namespace Banking
{
    public partial class AddUser : Form
    {
       Users hs = new Users();
        public AddUser()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
             
            User.AddUser(tbName.Text, tbUserName.Text, User.PassHasCod(tbPassword.Text), tbCashAcc.Text, tbClientId.Text, comboBox1.Text);
           
        }

    }
}
