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
    public partial class Sözleşme : Form
    {
        public Sözleşme()
        {
            InitializeComponent();
        }
        Araç_kiralama_oto arac = new Araç_kiralama_oto();   
        private void Sözleşme_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 150);
            // Ekranda belirli bir pozisyon 

            Boş_Araçlar();
            Yenile();

        }

        private void Boş_Araçlar()
        {
            string sorgu2 = "select * from araç where durumu='Boş'";
            arac.Boş_Araçlar(comboAraçlar, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select * from sözleşme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
           
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
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDönüş.Text) - DateTime.Parse(dateÇıkış.Text);
            int gun2 = gun.Days;
            txtGün.Text = gun2.ToString();
            txtTutar.Text=(gun2*int.Parse(txtKiraÜcreti.Text)).ToString();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            dateÇıkış.Text = DateTime.Now.ToShortDateString();
            dateDönüş.Text = DateTime.Now.ToShortDateString();
            comboKiraŞekli.Text = "";
            txtKiraÜcreti.Text = "";
            txtGün.Text = "";
            txtTutar.Text = "";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözleşme(adsoyad,tc,telefon,ehliyetno,e_tarih,e_yer,plaka,marka,seri,model,renk,kirasekli,kiraucreti,gun,tutar,c_tarih,d_tarih) values(@adsoyad,@tc,@telefon,@ehliyetno,@e_tarih,@e_yer,@plaka,@marka,@seri,@model,@renk,@kirasekli,@kiraucreti,@gun,@tutar,@c_tarih,@d_tarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@tc", txtTC.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@model", txtModel.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@c_tarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@d_tarih", dateDönüş.Text);

            arac.ekle_sil_güncelle(komut2, sorgu2);

            string sorgu3 = "update araç set durumu= 'Dolu' where plaka=@plaka";
            SqlCommand komut3 = new SqlCommand();
            komut3.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            arac.ekle_sil_güncelle(komut3, sorgu3);

            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();

            foreach (Control item in groupBox1.Controls)
                if (item is TextBox)
                    item.Text = "";

            foreach (Control item in groupBox2.Controls)
                if (item is TextBox)
                    item.Text = "";
            comboAraçlar.Text = "";

            Temizle();
            MessageBox.Show("Sözleşme başarı ile eklendi");
        }
        private void txtTCAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text == "'") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "'";
            string sorgu2 = "select * from müşteri where tc like '" + txtTCAra.Text + "'";
            arac.TC_Ara(txtTCAra,txtTC, txtAdSoyad, txtTelefon, sorgu2);
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözleşme set adsoyad=@adsoyad,tc=@tc,telefon=@telefon,ehliyetno=@ehliyetno,e_tarih=@e_tarih,marka=@marka,seri=@seri,model=@model,renk=@renk,kirasekli=@kirasekli,kiraucreti=@kiraucreti,gun=@gun,tutar=@tutar,ctarih=@ctarih,dtarih=@dtarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@tc", txtTC.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@model", txtModel.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraÜcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@c_tarih", dateÇıkış.Text);
            komut2.Parameters.AddWithValue("@d_tarih", dateDönüş.Text);

            arac.ekle_sil_güncelle(komut2, sorgu2);

            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();

            foreach (Control item in groupBox1.Controls)
                if (item is TextBox)
                    item.Text = "";

            foreach (Control item in groupBox2.Controls)
                if (item is TextBox)
                    item.Text = "";
            comboAraçlar.Text = "";

            Temizle();
            MessageBox.Show("Sözleşme başarı ile güncellendi");
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

        private void button7_Click(object sender, EventArgs e)
        {
            Satışlar satışlar = new Satışlar();
            satışlar.Show();
            this.Hide();
        }

     

        
    }
}
