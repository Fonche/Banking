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

namespace Banking
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string msg;
            bool res = User.checkLogin(tbUsername.Text, User.PassHasCod(tbPassword.Text), out msg);
           
                if (res)
                {
                    this.Hide();
                    HomePage FM = new HomePage();
                    FM.FormClosed += (s, args) => this.Close();
                    FM.Show();
                   
                }

             
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser FM = new AddUser();
            FM.FormClosed += (s, args) => this.Close();
            FM.Show();

        }
    }
}
