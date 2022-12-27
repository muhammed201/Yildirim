using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yildirim
{
    public partial class Oranlar : Form
    {
        public Oranlar()
        {
            InitializeComponent();
        }

        private string hataVar;
        void oranYukle()
        {
            string hataMesaji;
            try
            {                
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select * from Oranlar", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {                    
                    atolyePersonelYuzde.Text = dr["atolyePersonelYuzde"].ToString();
                    ogrenciHakkiYuzde.Text = dr["ogrenciHakkiYuzde"].ToString();
                    faliyetGideriYuzde.Text = dr["faliyetGideriYuzde"].ToString();
                    karYuzde.Text = dr["karYuzde"].ToString();
                    hazineHissesiYuzde.Text = dr["hazineHissesiYuzde"].ToString();
                    shcekPayiYuzde.Text = dr["shcekPayiYuzde"].ToString();
                    kdvTutariYuzde.Text = dr["kdvTutariYuzde"].ToString();
                }

                baglanti.Close();
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void oranGuncelle()
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;

                //Daha önceden bu alana kayıt yapılıp yapılmadığı kontrol ediliyor. Programın ilk kullanımında boş olacağı için bu alan programın ilk kurulduğunda bir kez çalışacak. 
                kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from Oranlar", ref hataMesaji);
                
                if (kayitVarmi != 0)
                {
                    veriTabani.veriGuncelle("UPDATE Oranlar SET atolyePersonelYuzde=" + atolyePersonelYuzde.Text.Trim() + ", ogrenciHakkiYuzde=" + ogrenciHakkiYuzde.Text.Trim() + ", faliyetGideriYuzde=" + faliyetGideriYuzde.Text.Trim() + ", karYuzde=" + karYuzde.Text.Trim() + ", hazineHissesiYuzde=" + hazineHissesiYuzde.Text.Trim() + ", shcekPayiYuzde=" + shcekPayiYuzde.Text.Trim() + ", kdvTutariYuzde=" + kdvTutariYuzde.Text.Trim() + ";", ref hataMesaji);
                    MessageBox.Show("Veriler güncellenmiştir","Veri Güncelleme",MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    veriTabani.veriEkle("INSERT INTO Oranlar ( atolyePersonelYuzde, ogrenciHakkiYuzde, faliyetGideriYuzde, karYuzde, hazineHissesiYuzde, shcekPayiYuzde, kdvTutariYuzde ) VALUES (" + atolyePersonelYuzde.Text.Trim() + "," + ogrenciHakkiYuzde.Text.Trim() + "," + faliyetGideriYuzde.Text.Trim() + "," + karYuzde.Text.Trim() + "," + hazineHissesiYuzde.Text.Trim() + "," + shcekPayiYuzde.Text.Trim() + "," + kdvTutariYuzde.Text.Trim() + ");", ref hataMesaji);
                    MessageBox.Show("Veriler güncellenmiştir", "Veri Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (hataMesaji == String.Empty)
                {
                    ;   //Herhangi bir hata bulunmamıştır. Bu yüzden bir işlem yaptırmıyoruz
                        //Bunun yerine != deyip kodu kısaltabilirdik ancak okunaklı olması için
                        //bu şekilde kalıp if then else kullanıldı. 
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu." + hataMesaji);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata: " + hata);
            }
        }
        void hataKontrolu()  //viewPanel içerisindeki textboxları temizliyoruz. 
        {
            try
            {
                hataVar = string.Empty;

                if (atolyePersonelYuzde.Text.Trim().Length == 0 || ogrenciHakkiYuzde.Text.Trim().Length == 0 || faliyetGideriYuzde.Text.Trim().Length == 0 || karYuzde.Text.Trim().Length == 0 || hazineHissesiYuzde.Text.Trim().Length == 0 || shcekPayiYuzde.Text.Trim().Length == 0 || kdvTutariYuzde.Text.Trim().Length == 0)
                {
                    hataVar = hataVar + " Boş alan tespit edildi." + Environment.NewLine;
                    return;
                }
                if (int.Parse(atolyePersonelYuzde.Text) > 100 || int.Parse(ogrenciHakkiYuzde.Text) > 100 || int.Parse(faliyetGideriYuzde.Text) > 100 || int.Parse(karYuzde.Text) > 100 || int.Parse(hazineHissesiYuzde.Text) > 100 || int.Parse(shcekPayiYuzde.Text) > 100 || int.Parse(kdvTutariYuzde.Text) > 100)
                {
                    hataVar = hataVar + " % değerler 100 sayısını geçemez." + Environment.NewLine;
                }
                if (int.Parse(atolyePersonelYuzde.Text) + int.Parse(ogrenciHakkiYuzde.Text) > 100)
                {
                    hataVar = hataVar + " Atölye Personel Ücreti % ile Öğrenci Hakkı Ücreti % toplam değeri 100 değerini geçemez." + Environment.NewLine;
                }
                if (int.Parse(atolyePersonelYuzde.Text) + int.Parse(ogrenciHakkiYuzde.Text) != 100)
                {
                    hataVar = hataVar + " Atölye Personel Ücreti % ile Öğrenci Hakkı Ücreti % toplam değeri 100 değerine eşit olmalıdır." + Environment.NewLine + "Örnek: Atölye Personel Ücreti%70, Öğrenci Hakkı Ücreti%30";
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata: " + hata.Message);
                hataVar = hataVar + " **************************************** ";
            }
        }
        private void Oranlar_Load(object sender, EventArgs e)
        {
            oranYukle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hataKontrolu();
            if(hataVar.ToString() != string.Empty)
            {
                MessageBox.Show("Bazı hatalarla karşılaşıldı. Lütfen hataları giderdikten sonra tekrar deneyiniz..." + Environment.NewLine + " " + hataVar.ToString() ,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                oranGuncelle();
            }            
        }
    }
}
