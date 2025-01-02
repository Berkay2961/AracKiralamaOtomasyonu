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
    public partial class Sözleşme : Form
    {
        public Sözleşme()
        {
            InitializeComponent();
        }
        Araç_kiralama_oto arac = new Araç_kiralama_oto();   
        private void Sözleşme_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where durumu='Boş'";
            arac.Boş_Araçlar(comboAraçlar,sorgu2);
        }
        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text == "'") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "'";
            string sorgu2 = "select * from müşteri where tc like '" + txtTC.Text + "'";
            arac.TC_Ara(txtTC,txtAdSoyad,txtTelefon,sorgu2);
        }
        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.Combodan_Getir(comboAraçlar,txtMarka,txtSeri,txtModel,txtRenk, sorgu2);
        }
        private void comboKiraŞekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.Ücret_Hesapla(comboKiraŞekli,txtKiraÜcreti,sorgu2);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Kazalıaraçlar kzlaraç = new Kazalıaraçlar();
            kzlaraç.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Araçlistele arclstl = new Araçlistele();
            arclstl.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Araçekle arcekle = new Araçekle();
            arcekle.Show();
            this.Hide();
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

        }

     
    }
}
