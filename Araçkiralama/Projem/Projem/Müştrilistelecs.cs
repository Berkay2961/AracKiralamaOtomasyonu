using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projem
{
    public partial class Müştrilistele : Form
    {
        Araç_kiralama_oto arackiralama = new Araç_kiralama_oto();
        public Müştrilistele()
        {
            InitializeComponent();
        }
        private void Müştrilistele_Load(object sender, EventArgs e)
        {
            YenileListele();
        }

        private void YenileListele()
        {
            string cümle = "select * from müşteri";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
           //kolon başlıklarını değiştirir
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
            dataGridView1.Columns[1].HeaderText = "TC";
            dataGridView1.Columns[0].HeaderText = "AD SOYAD";
            dataGridView1.Columns[2].HeaderText = "TELEFON";
            dataGridView1.Columns[3].HeaderText = "ADRES";
            dataGridView1.Columns[4].HeaderText = "E-MAİL";
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QT2PTBG\\SQLEXPRESS;Initial Catalog=Araç_kiralama_oto;Integrated Security=True");

            string cümle = $"select * from müşteri where tc like '{textBox6.Text}%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter(cümle,baglanti);
            DataTable tablo= new DataTable();

            adtr2.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            AdSoyad.Text=satır.Cells[0].Value.ToString();
            TC.Text = satır.Cells[0].Value.ToString();
            Telefon.Text = satır.Cells[0].Value.ToString();
            Adres.Text = satır.Cells[0].Value.ToString();
            Email.Text = satır.Cells[0].Value.ToString();

        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QT2PTBG\\SQLEXPRESS;Initial Catalog=Araç_kiralama_oto;Integrated Security=True");
            baglanti.Open();
            string cümle = $"update müşteri set adsoyad ='{AdSoyad.Text}',telefon='{Telefon.Text}',adres='{Adres.Text}',email='{Email.Text}' where tc='{TC.Text}'";
            SqlCommand komut2 = new SqlCommand(cümle,baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            

            string cümle1 = $"select * from müşteri where tc like '{textBox6.Text}%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter(cümle1, baglanti);
            DataTable tablo = new DataTable();
            adtr2.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

            //komut2.Parameters.AddWithValue("adsoyad",AdSoyad.Text);
            //komut2.Parameters.AddWithValue("tc", TC.Text);
            //komut2.Parameters.AddWithValue("telefon", Telefon.Text);
            //komut2.Parameters.AddWithValue("adres", Adres.Text);
            //komut2.Parameters.AddWithValue("email", Email.Text);
            //arackiralama.ekle_sil_güncelle(komut2, cümle);
            ////işlemin olup olmadığını görmek için
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            //YenileListele();

        }
        private void sil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from müşteri where tc='"+satır.Cells["tc"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_güncelle(komut2, cümle);
         
            YenileListele();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Araçekle arcekle = new Araçekle();
            arcekle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Araçlistele arclstl = new Araçlistele();
            arclstl.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sözleşme szlşm = new Sözleşme();
            szlşm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Kazalıaraçlar kzlaraç = new Kazalıaraçlar();
            kzlaraç.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müşteriekle mştrekle = new Müşteriekle();
            mştrekle.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Satışlar satışlar = new Satışlar();
            satışlar.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anasayfacs anasyf = new Anasayfacs();
            anasyf.Show();
            this.Hide();
        }

        
    }
}
