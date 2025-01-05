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

namespace Projem
{
    public partial class Satışlar : Form
    {
        public Satışlar()
        {
            InitializeComponent();
        }
        Araç_kiralama_oto arac= new Araç_kiralama_oto();
        private void Satışlar_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 150);
            // Ekranda belirli bir pozisyon 

            string sorgu2 = "select * from satış";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2,sorgu2);
            arac.satışhesapla(label1);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Müştrilistele mştls = new Müştrilistele();
            mştls.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Müşteriekle mştrekle = new Müşteriekle();
            mştrekle.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anasayfacs anasyf = new Anasayfacs();
            anasyf.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Araçekle arcekle = new Araçekle();
            arcekle.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Araçlistele arclstl = new Araçlistele();
            arclstl.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Sözleşme szlşm = new Sözleşme();
            szlşm.Show();
            this.Hide();
        }

     
    }
}
