﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projem
{
    internal class Araç_kiralama_oto

    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QT2PTBG\\SQLEXPRESS;Initial Catalog=Araç_kiralama_oto;Integrated Security=True");
        DataTable tablo;
        public void ekle_sil_güncelle(SqlCommand komut, string sorgu)
        {

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();

         
         
         


 
        }

        public DataTable listele(SqlDataAdapter adtr,string sorgu)
        {
            tablo = new DataTable();  
            adtr = new SqlDataAdapter(sorgu,baglanti);
            adtr.Fill(tablo);
            
            baglanti.Close();
            return tablo;
            

        }
        public void Boş_Araçlar(ComboBox combo,string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglanti.Close();
        }
        public void TC_Ara(TextBox tc,TextBox adsoyad,TextBox telefon, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text = read["telefon"].ToString();

            }
            baglanti.Close();
        }
    }

}