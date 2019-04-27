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
namespace Banking
{
    public partial class AddAccountClasses : Form
    {
        public AddAccountClasses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AccountClass.ADD(textBox1.Text, textBox2.Text, textBox3.Text);
           
        }
    }
}
