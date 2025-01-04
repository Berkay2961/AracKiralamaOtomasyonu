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
    public partial class Araçekle : Form
    {
        Araç_kiralama_oto arackiralama = new Araç_kiralama_oto();
        public Araçekle()
        {
            InitializeComponent();
        }

     

        private void button10_Click(object sender, EventArgs e)
        {
            Sözleşme szlşm = new Sözleşme();
            szlşm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Araçlistele arclstl = new Araçlistele();
            arclstl.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Satışlar satışlar = new Satışlar();
            satışlar.Show();
            this.Hide();
        }

        private void ResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox3.ImageLocation = openFileDialog1.FileName;
        }

        private void İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("Focus");
                    Sericombo.Items.Add("Fıesta");
                    Sericombo.Items.Add("Puma");
                }
                else if (Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("Talisman");
                    Sericombo.Items.Add("Megane");
                    Sericombo.Items.Add("Clio");
                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("Egea");
                    Sericombo.Items.Add("Fiorino");
                    Sericombo.Items.Add("Doblo");
                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("Tucson");
                    Sericombo.Items.Add("Bayon");
                    Sericombo.Items.Add("Kona");
                }
                else if (Markacombo.SelectedIndex == 4)
                {
                    Sericombo.Items.Add("Astra");
                    Sericombo.Items.Add("Mokka");
                    Sericombo.Items.Add("Crossland x");
                }
                else if (Markacombo.SelectedIndex == 5)
                {
                    Sericombo.Items.Add("A4");
                    Sericombo.Items.Add("A3");
                    Sericombo.Items.Add("A5");
                }
                else if (Markacombo.SelectedIndex == 6)
                {
                    Sericombo.Items.Add("320i");
                    Sericombo.Items.Add("520i");
                    Sericombo.Items.Add("520d");
                }

            }
            catch
            {
                ;
            }   
          
        }

        private void Kayıt_Click(object sender, EventArgs e)
        {

            string cümle = "insert into araç(plaka,marka,seri,model,renk,km,yakit,kiraucreti,resim,tarih,durumu) values (@plaka,@marka,@seri,@model,@renk,@km,@yakit,@kiraucreti,@resim,@tarih,@durumu)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka",Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@model", Modeltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox3.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "Boş");
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox3.ImageLocation = "";

            


        }

        private void Araçekle_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 150);
            // Ekranda belirli bir pozisyon 
        }
    }
}
