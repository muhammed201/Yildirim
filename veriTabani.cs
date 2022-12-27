using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Yildirim
{
    internal class veriTabani
    {
        public static DataTable vtbaglan(string gelenKomut)
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
            baglanti.Open();
            SQLiteDataAdapter veri = new SQLiteDataAdapter(gelenKomut, baglanti);                        
            DataTable tablo = new DataTable();
            veri.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public static int kullaniciSayisi(string gelenKomut, ref string hataMesaji)
        {
            try
            {
                int kulSayisi;
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand(gelenKomut, baglanti);
                //Aşağıdaki kodla kullanıcı sayısını hesaplıyoruz, diğer sorgular genelde ExecuteNonQuery() metoduyla yapılırken aşağıda ExecuteScalar() medoduyla yapılıp int32'ye çevriliyor.
                kulSayisi = Convert.ToInt32(kmt.ExecuteScalar());
                baglanti.Close();
                return kulSayisi;
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                return 0;

            }
        }

        public static bool veriEkle(string gelenKomut, ref string hataMesaji)
        {
            try
            {
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand(gelenKomut, baglanti);
                kmt.ExecuteNonQuery();

                baglanti.Close();
                return true;
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public static bool veriSil(string gelenKomut, ref string hataMesaji)
        {
            try
            {
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand(gelenKomut, baglanti);
                kmt.ExecuteNonQuery();

                //dataGridView1.DataSource = tablo;
                baglanti.Close();
                return true;
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                return false;

            }
        }

        public static bool veriGuncelle(string gelenKomut, ref string hataMesaji)
        {
            try
            {
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand(gelenKomut, baglanti);
                kmt.ExecuteNonQuery();

                //dataGridView1.DataSource = tablo;
                baglanti.Close();
                return true;
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                return false;

            }
        }
    }
}
