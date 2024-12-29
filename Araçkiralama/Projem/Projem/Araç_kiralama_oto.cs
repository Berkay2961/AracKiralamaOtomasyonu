using System;
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
    }

}