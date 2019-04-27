using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clients FM = new Clients();
            FM.Closed += (s, args) => this.Close();
            FM.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser FM = new AddUser();
            
            FM.Show();
        }

        private void insertUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateAccountCassesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insertTransactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users FM = new Users();
             FM.Show();
        }

        private void cleintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients FM = new Clients();
           
            FM.Show();
        }

        private void insertAccoutClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccountClasses FM = new AddAccountClasses();

            FM.Show();
        }

      

        private void evidencijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts FM = new Accounts();

            FM.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            if (!Common.Common.role.Equals("Admin"))
            {
                usersToolStripMenuItem.Enabled = false;
                accountCassesToolStripMenuItem.Enabled = false;

                accountTypeToolStripMenuItem.Enabled = false;
                transactionsTypeToolStripMenuItem.Enabled = false;
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pp1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void evidencijaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TransEvidencija FM = new TransEvidencija();

            FM.Show();
        }

        private void pP10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP_10 p = new PP_10();
            p.Show();
        }

        private void pP30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP_30 p = new PP_30();
            p.Show();
        }

        private void pP40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP_40 p = new PP_40();
            p.Show();
        }

        private void evidencijaNaTransakciiVoFinalenStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransFinal tr = new TransFinal();
            tr.Show();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccounts a1 = new AddAccounts();
            a1.Show();
        }
    }
}
