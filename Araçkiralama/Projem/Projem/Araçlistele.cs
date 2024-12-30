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
    public partial class Araçlistele : Form
    {
        Araç_kiralama_oto arackiralama=new Araç_kiralama_oto();
        public Araçlistele()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            comboBox1.Text = satır.Cells["plaka"].Value.ToString();
            Markacombo.Text = satır.Cells["marka"].Value.ToString();
            Sericombo.Text = satır.Cells["seri"].Value.ToString();
            Modeltxt.Text = satır.Cells["model"].Value.ToString();
            Renktxt.Text = satır.Cells["renk"].Value.ToString();
            Kmtxt.Text = satır.Cells["km"].Value.ToString();
            Yakıtcombo.Text = satır.Cells["yakıt"].Value.ToString();
            Ücrettxt.Text = satır.Cells["ücret"].Value.ToString();
            pictureBox3.ImageLocation = satır.Cells["resim"].Value.ToString();
            
            
        }
        private void Araçlistele_Load(object sender, EventArgs e)
        {
            YenileAraçlarListesi();

                comboAraçlar.SelectedIndex = 0;
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QT2PTBG\\SQLEXPRESS;Initial Catalog=Araç_kiralama_oto;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select plaka from araç ", baglanti);
            SqlDataReader veri= cmd.ExecuteReader();
            while (veri.Read())
            {
                comboBox1.Items.Add(veri[0].ToString());

            }
            baglanti.Close();

        }

        private void YenileAraçlarListesi()
        {
            string cümle = "select * from araç";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }
        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox3.ImageLocation=openFileDialog1.FileName;
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update araç set marka=@marka,seri=@seri,model=@model,renk=@renk,km=@km,yakit=@yakit,kiraucreti=@kiraucreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka",comboBox1.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@model", Modeltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox3.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox3.ImageLocation = "";
            YenileAraçlarListesi();


        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from araç where plaka='" + comboBox1.Text + "'";
            SqlCommand komut2 = new SqlCommand(); 
            arackiralama.ekle_sil_güncelle(komut2,cümle);
            YenileAraçlarListesi();
            pictureBox3.ImageLocation = "";
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            
        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
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
        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboAraçlar.SelectedIndex == 0)
                {
                    YenileAraçlarListesi();
                }
                if (comboAraçlar.SelectedIndex == 1)
                {
                    string cümle = "select * from araç where durumu ='DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (comboAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select * from araç where durumu ='BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch 
            {
                ;
            }
        }
        //plakayı seçince resim çıkar
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QT2PTBG\\SQLEXPRESS;Initial Catalog=Araç_kiralama_oto;Integrated Security=True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand($"select resim from araç where plaka='{comboBox1.Text}'", baglanti);
            SqlDataReader veri = cmd.ExecuteReader();
            while (veri.Read())
            {

                pictureBox3.ImageLocation = veri[0].ToString();
            }
            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Sözleşme szlşm = new Sözleşme();
            szlşm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Kazalıaraçlar kzlaraç = new Kazalıaraçlar();
            kzlaraç.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Araçekle arcekle = new Araçekle();
            arcekle.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Müşteriekle mştrekle = new Müşteriekle();
            mştrekle.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Müştrilistele mştls = new Müştrilistele();
            mştls.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anasayfacs anasyf = new Anasayfacs();
            anasyf.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Satışlar satışlar = new Satışlar();
            satışlar.Show();
            this.Hide();
        }

    

        

           
        }
    }


   

