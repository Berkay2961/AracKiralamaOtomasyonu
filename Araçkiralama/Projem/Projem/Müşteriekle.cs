﻿using System;
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
    public partial class Müşteriekle : Form
    {
        Araç_kiralama_oto arac_kiralama = new Araç_kiralama_oto();
        public Müşteriekle()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anasayfacs anasyf = new Anasayfacs();
            anasyf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //müşteri ekleme
            string cümle = $"insert into müşteri(adsoyad,tc,telefon,adres,email) values('{txtAdsoyad.Text}','{txtTC.Text}','{txtTelefon.Text}','{txtAdres.Text}','{txtEmail.Text}')";
            SqlCommand komut2 = new SqlCommand();
            //komut2.Parameters.AddWithValue("_adsoyad",txtAdsoyad.Text);
            //komut2.Parameters.AddWithValue("_tc", txtTC.Text);
            //komut2.Parameters.AddWithValue("_telefon", txtTelefon.Text);
            //komut2.Parameters.AddWithValue("_adres", txtAdres.Text);
            //komut2.Parameters.AddWithValue("_email", txtEmail.Text);
            arac_kiralama.ekle_sil_güncelle(komut2,cümle);
            //işlemin olup olmadığını görmek için
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";

            MessageBox.Show("Müşteri başarı ile eklenmiştir.");

        }

        private void Müşteriekle_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Müştrilistele mştls = new Müştrilistele();
            mştls.Show();
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

        private void button9_Click(object sender, EventArgs e)
        {
            Kazalıaraçlar kzlaraç = new Kazalıaraçlar();
            kzlaraç.Show();
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
