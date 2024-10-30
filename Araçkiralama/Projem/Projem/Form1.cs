using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kuladi = textBox1.Text;
            string sifre = textBox2.Text;
            if (kuladi == "1" && sifre == "1")
            {
                Anasayfacs anasyf = new Anasayfacs();
                anasyf.Show();
                this.Hide();
            }
        }
    }
}

