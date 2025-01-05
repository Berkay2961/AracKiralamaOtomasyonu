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
            if (txtTCAra.Text == "'") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "'";
            string sorgu2 = "select * from müşteri where tc like '" + txtTCAra.Text + "'";
            arac.TC_Ara(txtTCAra,txtTC, txtAdSoyad, txtTelefon, sorgu2);
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözleşme set adsoyad=@adsoyad,tc=@tc,telefon=@telefon,ehliyetno=@ehliyetno,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,model=@model,renk=@renk,kirasekli=@kirasekli,kiraucreti=@kiraucreti,gun=@gun,tutar=@tutar,c_tarih=@c_tarih,d_tarih=@d_tarih where plaka=@plaka";
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtAdSoyad.Text = satır.Cells[0].Value.ToString();
            txtTC.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtE_No.Text = satır.Cells[3].Value.ToString();
            txtE_No.Text = satır.Cells[4].Value.ToString();
            txtE_Yer.Text = satır.Cells[5].Value.ToString();
            comboAraçlar.Text = satır.Cells[6].Value.ToString();
            txtMarka.Text = satır.Cells[7].Value.ToString();
            txtSeri.Text = satır.Cells[8].Value.ToString();
            txtModel.Text = satır.Cells[9].Value.ToString();
            txtRenk.Text = satır.Cells[10].Value.ToString();
            comboKiraŞekli.Text = satır.Cells[11].Value.ToString();
            txtKiraÜcreti.Text = satır.Cells[12].Value.ToString();
            txtGün.Text = satır.Cells[13].Value.ToString();
            txtTutar.Text = satır.Cells[14].Value.ToString();
            dateÇıkış.Text = satır.Cells[15].Value.ToString();
            dateDönüş.Text = satır.Cells[16].Value.ToString();


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            //Gün farkı hesaplama
            DateTime bugün=DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dönüş =DateTime.Parse(satır.Cells["d_tarih"].Value.ToString());
            int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString()) ;
            TimeSpan gunfarkı = bugün - dönüş;
            int _gunfarkı = gunfarkı.Days;
            int ucretfarkı;
            //ücret farkını hesaplama
            ucretfarkı = _gunfarkı * ucret;
            txtEkstra.Text=ucretfarkı.ToString();
            //toplam tutar hesapla

        }
        private void btnAraçTeslim_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtEkstra.Text)>=0 || int.Parse(txtEkstra.Text)<0)
            {
                DataGridViewRow satır = dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
                int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
                DateTime çıkış = DateTime.Parse(satır.Cells["c_tarih"].Value.ToString());
                TimeSpan gun = bugün - çıkış;
                int _gun = gun.Days;
                int toplamtutar = _gun * ucret;
                //toplamtutar, _gun ve ücret satış tablosuna aktarılacak
                string sorgu1 = "delete from sözleşme where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut = new SqlCommand();
                arac.ekle_sil_güncelle(komut, sorgu1);
                string sorgu2 = "update araç set durumu='Boş' where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                arac.ekle_sil_güncelle(komut3, sorgu2);

                string sorgu3 = "insert into satış(adsoyad,tc,plaka,marka,seri,model,renk,gun,tutar,tarih_1,tarih_2,fiyat) values(@adsoyad,@tc,@plaka,@marka,@seri,@model,@renk,@gun,@tutar,@tarih_1,@tarih_2,@fiyat)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@adsoyad", satır.Cells["adsoyad"].Value.ToString());
                komut2.Parameters.AddWithValue("@tc", satır.Cells["tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@model", satır.Cells["model"].Value.ToString());
                komut2.Parameters.AddWithValue("@renk", satır.Cells["renk"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun", _gun);
                komut2.Parameters.AddWithValue("@tutar", toplamtutar);
                komut2.Parameters.AddWithValue("@tarih_1", satır.Cells["c_tarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih_2", DateTime.Now.ToShortDateString());
                komut2.Parameters.AddWithValue("@fiyat", ucret);
                arac.ekle_sil_güncelle(komut2, sorgu3);

                MessageBox.Show("Araç teslim edildi");
                comboAraçlar.Text = "";
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

                txtEkstra.Text = "";
            }
            else 
            {
                MessageBox.Show("Lütfen seçim yapınız", "Uyarı");
            }
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
