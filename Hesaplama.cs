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
    public partial class hisseFormulu : Form
    {
        public hisseFormulu()
        {
            InitializeComponent();
        }

        void kurumYukle()
        {
            string hataMesaji;
            try
            {
                //Önceden başka tabloda tanımlanan görevler Combobox'a aktarılıyor
                //duty comboboxını temizliyoruz yoksa tekrara düşüyor.
                kurumAdi.Items.Clear();
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select kurumAdi from Kurumlar", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    kurumAdi.Items.Add(dr["kurumAdi"].ToString());
                }

                baglanti.Close();
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void uretimYapanAlanYukle()
        {
            string hataMesaji;
            try
            {
                //Önceden başka tabloda tanımlanan görevler Combobox'a aktarılıyor
                //duty comboboxını temizliyoruz yoksa tekrara düşüyor.
                uretimYapilanAlan.Items.Clear();
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select bolumler from Bolumler", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    uretimYapilanAlan.Items.Add(dr["bolumler"].ToString());
                }

                baglanti.Close();
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void siparisVerenYukle()
        {
            string hataMesaji;
            try
            {                
                siparisVeren.Items.Clear();
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select * from siparisVerenler", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    siparisVeren.Items.Add(dr["siparisVeren"].ToString());                    
                }

                baglanti.Close();
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void siparisVerenYukleComboBox() //siparisVeren Combobox'ı tıklandığında verileri çekecek olan fonksiyon. 
        {
            string hataMesaji;
            try
            {                
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select * from siparisVerenler where siparisVeren like '" + siparisVeren.Text + "'", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    vergiKimlikNu.Text = dr["vergiKimlikNu"].ToString();
                    vergiDairesi.Text = dr["vergiDairesi"].ToString();
                    ilgiliTel.Text = dr["ilgiliTel"].ToString();
                    ilgiliFaks.Text = dr["ilgiliFaks"].ToString();
                    ilgiliEposta.Text = dr["ilgiliEposta"].ToString();
                    ilgiliAcikAdres.Text = dr["ilgiliAcikAdres"].ToString();
                    ilgiliIl.Text = dr["ilgiliIl"].ToString();
                    ilgiliIlce.Text = dr["ilgiliIlce"].ToString();
                }

                baglanti.Close();
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void siparisVerenler()
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;

                //Bu isimde bir kurum olup olmadığını kontrol ediyoruz
                kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from siparisVerenler where siparisVeren like '" + siparisVeren.Text + "'", ref hataMesaji);
                

                if (kayitVarmi != 0)
                {
                    veriTabani.veriGuncelle("UPDATE siparisVerenler SET siparisVeren='" + siparisVeren.Text.Trim() + "', vergiKimlikNu='" + vergiKimlikNu.Text.Trim() + "', vergiDairesi='" + vergiDairesi.Text.Trim() + "', ilgiliTel='" + ilgiliAcikAdres.Text.Trim() + "', ilgiliFaks='" + ilgiliFaks.Text.Trim() + "', ilgiliEposta='" + ilgiliEposta.Text.Trim() + "', ilgiliAcikAdres='" + ilgiliAcikAdres.Text.Trim() + "',ilgiliIl='" + ilgiliIl.Text.Trim() + "', ilgiliIlce='" + ilgiliIlce.Text.Trim() + "' WHERE siparisVeren='" + siparisVeren.Text + "'", ref hataMesaji);
                    return;
                }
                else
                {
                    veriTabani.veriEkle("INSERT INTO siparisVerenler (siparisVeren, vergiKimlikNu, vergiDairesi, ilgiliTel, ilgiliFaks, ilgiliEposta, ilgiliAcikAdres, ilgiliIl, ilgiliIlce ) VALUES ('" + siparisVeren.Text.Trim() + "','" + vergiKimlikNu.Text.Trim() + "','" + vergiDairesi.Text.Trim() + "','" + ilgiliTel.Text.Trim() + "','" + ilgiliFaks.Text.Trim() + "','" + ilgiliEposta.Text.Trim() + "','" + ilgiliAcikAdres.Text.Trim() + "','" + ilgiliIl.Text.Trim() + "','" + ilgiliIlce.Text.Trim() + "');", ref hataMesaji);
                }

                if (hataMesaji == String.Empty)
                {
                    ;   //Herhangi bir hata bulunmamıştır. Bu yüzden bir işlem yaptırmıyoruz
                        //Bunun yerine != deyip kodu kısaltabilirdik ancak okunaklı olması için
                        //bu şekilde kalıp if then else kullanıldı. 
                }
                else
                {
                    MessageBox.Show("Sipariş Veren bilgilerini kayıt ederken bir hata oluştu." + hataMesaji);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Sipariş veren bilgilerini kayıt ederken bir hata oluştu. Hata: " + hata);
            }
        }
        private void hisseFormulu_Load(object sender, EventArgs e)
        {
            kurumYukle();
            uretimYapanAlanYukle();
            siparisVerenYukle();


        }

        private void uretimBaslamaTarihi_Enter(object sender, EventArgs e)
        {
            uretimeBaslamaTakvimi.Visible = true;
        }

        private void uretimBitimTarihi_Enter(object sender, EventArgs e)
        {
            uretiminBitisiTakvim.Visible=true;
        }

        private void uretimeBaslamaTakvimi_DateChanged(object sender, DateRangeEventArgs e)
        {            
            uretimBaslamaTarihi.Text = uretimeBaslamaTakvimi.SelectionStart.ToString("dd.MM.yyyy");
        }

        private void uretiminBitisiTakvim_DateChanged(object sender, DateRangeEventArgs e)
        {            
            uretimBitimTarihi.Text = uretiminBitisiTakvim.SelectionStart.ToString("dd.MM.yyyy");
        }

        private void uretimeBaslamaTakvimi_Leave(object sender, EventArgs e)
        {
            uretimeBaslamaTakvimi.Visible=false;
        }

        private void uretiminBitisiTakvim_Leave(object sender, EventArgs e)
        {
            uretiminBitisiTakvim.Visible = false;
        }

        private void uretimBaslamaTarihi_Leave(object sender, EventArgs e)
        {
            uretimeBaslamaTakvimi.Visible = false;
        }

        private void uretimBitimTarihi_Leave(object sender, EventArgs e)
        {
            uretiminBitisiTakvim.Visible=false;
        }

        private void ilkMalzemeTutari_Leave(object sender, EventArgs e)
        {
            try
            {
                ilkMalzemeTutari.Text = string.Format("{0:N2}", Convert.ToDouble(ilkMalzemeTutari.Text));
            }
            catch 
            { 
                ilkMalzemeTutari.Text="0,00";
            }
            
        }

        private void faydaHizmetler_Leave(object sender, EventArgs e)
        {
            try
            {
                faydaHizmetler.Text = string.Format("{0:N2}", Convert.ToDouble(faydaHizmetler.Text));
            }
            catch
            {
                faydaHizmetler.Text = "0,00";
            }            
        }

        private void iscilikTutari_Leave(object sender, EventArgs e)
        {
            try
            {
                iscilikTutari.Text = string.Format("{0:N2}", Convert.ToDouble(iscilikTutari.Text));
            }
            catch
            {
                iscilikTutari.Text = "0,00";
            }            
        }

        private void personelUcreti_Leave(object sender, EventArgs e)
        {
            try
            {
                personelUcreti.Text = string.Format("{0:N2}", Convert.ToDouble(personelUcreti.Text));
            }
            catch
            {
                personelUcreti.Text = "0,00";
            }            
        }

        private void ogrenciUcreti_Leave(object sender, EventArgs e)
        {
            try
            {
                ogrenciUcreti.Text = string.Format("{0:N2}", Convert.ToDouble(ogrenciUcreti.Text));
            }
            catch
            {
                ogrenciUcreti.Text = "0,00";
            }            
        }

        private void iscilikToplam_Leave(object sender, EventArgs e)
        {
            try
            {
                iscilikToplam.Text = string.Format("{0:N2}", Convert.ToDouble(iscilikToplam.Text));
            }
            catch
            {
                iscilikToplam.Text = "0,00";
            }            
        }

        private void faliyetGideri_Leave(object sender, EventArgs e)
        {
            try
            {
                faliyetGideri.Text = string.Format("{0:N2}", Convert.ToDouble(faliyetGideri.Text));
            }
            catch
            {
                faliyetGideri.Text = "0,00";
            }            
        }

        private void kar_Leave(object sender, EventArgs e)
        {
            try
            {
                kar.Text = string.Format("{0:N2}", Convert.ToDouble(kar.Text));
            }
            catch
            {
                kar.Text = "0,00";
            }            
        }

        private void hazineHissesi_Leave(object sender, EventArgs e)
        {
            try
            {
                hazineHissesi.Text = string.Format("{0:N2}", Convert.ToDouble(hazineHissesi.Text));
            }
            catch
            {
                hazineHissesi.Text = "0,00";
            }            
        }

        private void shcekPayi_Leave(object sender, EventArgs e)
        {
            try
            {
                shcekPayi.Text = string.Format("{0:N2}", Convert.ToDouble(shcekPayi.Text));
            }
            catch
            {
                shcekPayi.Text = "0,00";
            }
        }

        private void Toplam_Leave(object sender, EventArgs e)
        {
            try
            {
                Toplam.Text = string.Format("{0:N2}", Convert.ToDouble(Toplam.Text));
            }
            catch
            {
                Toplam.Text = "0,00";
            }            
        }

        private void satisTutariKdvsiz_Leave(object sender, EventArgs e)
        {
            try
            {
                satisTutariKdvsiz.Text = string.Format("{0:N2}", Convert.ToDouble(satisTutariKdvsiz.Text));
            }
            catch
            {
                satisTutariKdvsiz.Text = "0,00";
            }            
        }

        private void kdvTutari_Leave(object sender, EventArgs e)
        {
            try
            {
                kdvTutari.Text = string.Format("{0:N2}", Convert.ToDouble(kdvTutari.Text));
            }
            catch
            {
                kdvTutari.Text = "0,00";
            }            
        }

        private void satisTutariKdvli_Leave(object sender, EventArgs e)
        {
            try
            {
                satisTutariKdvli.Text = string.Format("{0:N2}", Convert.ToDouble(satisTutariKdvli.Text));
            }
            catch
            {
                satisTutariKdvli.Text = "0,00";
            }            
        }

        private void enazSatisTutari_Leave(object sender, EventArgs e)
        {
            try
            {
                enazSatisTutari.Text = string.Format("{0:N2}", Convert.ToDouble(enazSatisTutari.Text));
            }
            catch
            {
                enazSatisTutari.Text = "0,00";
            }
            
        }

        private void atolyePersonelUcreti_Leave(object sender, EventArgs e)
        {
            try
            {
                atolyePersonelUcreti.Text = string.Format("{0:N2}", Convert.ToDouble(atolyePersonelUcreti.Text));
            }
            catch
            {
                atolyePersonelUcreti.Text = "0,00";
            }            
        }

        private void ogrenciHakkiUcreti_Leave(object sender, EventArgs e)
        {
            try
            {
                ogrenciHakkiUcreti.Text = string.Format("{0:N2}", Convert.ToDouble(ogrenciHakkiUcreti.Text));
            }
            catch
            {
                ogrenciHakkiUcreti.Text = "0,00";
            }            
        }

        private void idariPersonelUcreti_Leave(object sender, EventArgs e)
        {
            try
            {
                idariPersonelUcreti.Text = string.Format("{0:N2}", Convert.ToDouble(idariPersonelUcreti.Text));
            }
            catch
            {
                idariPersonelUcreti.Text = "0,00";
            }            
        }

        private void gnyKar_Leave(object sender, EventArgs e)
        {
            try
            {
                gnyKar.Text = string.Format("{0:N2}", Convert.ToDouble(gnyKar.Text));
            }
            catch
            {
                gnyKar.Text = "0,00";
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siparisVerenler();
        }

        private void siparisVeren_SelectedValueChanged(object sender, EventArgs e)
        {            
            siparisVerenYukleComboBox();
        }
    }
}
