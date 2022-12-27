using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Yildirim
{
    public partial class Ogrenciler : Form
    {
        double oranW, oranH;
        public Ogrenciler()
        {
            InitializeComponent();
        }

        string okulID;
        public void yeniBoyut()
        {
            int sizeW = Convert.ToInt32(this.Size.Width * oranW);
            int sizeH = Convert.ToInt32(this.Size.Height * oranH);
            dataGridPanel.Size = new Size(sizeW, sizeH);
            dataGrid.Size = new Size(sizeW - 10, sizeH - 10);
        }

        void veriYukle()
        {
            string hataMesaji;
            try
            {
                //Önceden başka tabloda tanımlanan görevler Combobox'a aktarılıyor
                //okulu comboboxını temizliyoruz yoksa tekrara düşüyor.
                okulu.Items.Clear();
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
                baglanti.Open();

                SQLiteCommand kmt = new SQLiteCommand("Select kurumAdi from Kurumlar", baglanti);
                kmt.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    okulu.Items.Add(dr["kurumAdi"].ToString());
                }

                baglanti.Close();                
            }
            catch (Exception sorun)
            {
                hataMesaji = sorun.Message;
                MessageBox.Show("Bir hata oluştu. Hata: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        void oranYukle()
        {
            int say;
                
            for(say=0; say<=10; say++)
            {
                oran.Items.Add(say.ToString());
            }            
        }
        void veriIdBul(string cKurum)
        {
            //Herhangi bir hata durumunda bu fonksiyonun doğru çalışmama durumuna karşın okulID değeri boşaltılıyor böylece yanlış id atama riski kaldırılıyor
            okulID = String.Empty;
                        
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=vt/aksehirmeb.db");
            baglanti.Open();

            SQLiteCommand kmt = new SQLiteCommand("Select * from Kurumlar where kurumAdi like '" + cKurum + "'", baglanti);
            kmt.ExecuteNonQuery();



            DataTable dt = new DataTable();
            SQLiteDataAdapter adp = new SQLiteDataAdapter(kmt);
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                okulID = (dr["kurumid"].ToString()); //Kurumun bulunan id'si kayıt işlemi sırasında kullanılmak üzere okulID'ye aktarılıyor
            }

            baglanti.Close();
        }

        void dataGridCaption()
        {
            dataGrid.Columns[0].HeaderText = "Adı";
            dataGrid.Columns[1].HeaderText = "Soyadı";
            dataGrid.Columns[2].HeaderText = "Tc Kimlik Numarası";
            dataGrid.Columns[3].HeaderText = "İBAN";
            dataGrid.Columns[4].HeaderText = "Okulu";
            dataGrid.Columns[5].HeaderText = "Oran";
            dataGrid.Columns[6].HeaderText = "Açıklama";            
        }

        public bool boslukKontrol()  //Textboxlarda boşluk olup olmadığını kontrol ediyoruz
        {
            foreach (Control item in viewPanel.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    //if (txt.Name== "internalphone") satırı ile internalphone değişkenin boş olup olmadığı atlanıyor. Boş olsa dahi kayıt gerçekleşecek.
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        if (txt.Name == "aciklama") //Açıklama metni girilmek zorunda değil
                        {
                            ;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        void viewPanelEmpty()  //viewPanel içerisindeki textboxları temizliyoruz. 
        {
            foreach (Control item in viewPanel.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;                    
                    txt.Text = string.Empty;
                }
                if(item is ComboBox)
                {
                    ComboBox cmb = item as ComboBox;
                    cmb.Text = string.Empty;
                    cmb.Items.Clear();
                }
            }
            seciliDegisken.Text = string.Empty;
        }
        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            string hataMesaji = string.Empty;
            dataGrid.DataSource = veriTabani.vtbaglan("Select Ogrenci.adi, Ogrenci.soyadi, Ogrenci.tckimlikNu, Ogrenci.iban, Kurumlar.kurumAdi, Ogrenci.oran, Ogrenci.aciklama from (Ogrenci INNER JOIN Kurumlar ON Ogrenci.okulu = Kurumlar.kurumid ) ORDER BY Ogrenci.adi ASC;");
            //                                                                                                                                                                                                  from ((staff INNER JOIN duties ON staff.duty = duties.idduties) INNER JOIN bilgiislem.courts ON staff.department = courts.idcourts)  ORDER BY staff.stafName ASC;");
            dataGridCaption(); //DataGridview başlıkları ayarlanıyor.
            veriYukle();
            oranYukle(); //Oran combobox'ı 10 a kadar dolduruyor.
            //Açılış değerlerini alıyor. Daha sonra yeniBoyut() fonksiyonu ile formun boyutu değiştikçe nesnelerin pozisyonları ve yerleri ayarlanıyor. 
            oranW = (double)dataGridPanel.Size.Width / (double)this.Size.Width;
            oranH = (double)dataGridPanel.Size.Height / (double)this.Size.Height;
            dataGrid.ScrollBars = ScrollBars.Both;
        }

        private void kayitEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;

                //Bu isimde bir kurum olup olmadığını kontrol ediyoruz
                kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from Ogrenci where tckimlikNu like '" + tckimlikNu.Text + "'", ref hataMesaji);
                veriIdBul(okulu.Text);
                if (boslukKontrol() != true) //Boşluk olup olmadığını kontrol eden method çağırılıyor
                {
                    MessageBox.Show("Boş alanlar tespit edildi. Lütfen tüm alanları eksiksiz doldurduktan sonra tekrar deneyiniz", "Boş Alan Tespit Edildi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                else if (kayitVarmi != 0)
                {
                    MessageBox.Show("Bu isim ile daha önceden başka bir öğrenci kayıt edilmiş. Lütfen kontrol edip tekrar deneyiziniz", "Kayıt Tekrarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    veriTabani.veriEkle("INSERT INTO Ogrenci (adi, soyadi, tckimlikNu, oran, okulu, iban, aciklama ) VALUES ('" + adi.Text.Trim() + "','" + soyadi.Text.Trim() + "','" + tckimlikNu.Text.Trim() + "','" + oran.Text.Trim() + "'," + okulID + ",'" + iban.Text.Trim() + "','" + aciklama.Text.Trim() + "');", ref hataMesaji);
                }

                if (hataMesaji == String.Empty)
                {
                    MessageBox.Show("Kayıt başarılı");

                    dataGrid.DataSource = veriTabani.vtbaglan("Select Ogrenci.adi, Ogrenci.soyadi, Ogrenci.tckimlikNu, Ogrenci.iban, Kurumlar.kurumAdi, Ogrenci.oran, Ogrenci.aciklama from (Ogrenci INNER JOIN Kurumlar ON Ogrenci.okulu = Kurumlar.kurumid ) ORDER BY Ogrenci.adi ASC;");
                    viewPanelEmpty(); //Textbox'ları temizliyoruz
                    veriYukle();
                    oranYukle();
                }
                else
                {
                    MessageBox.Show(hataMesaji);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata: " + hata);
            }
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            viewPanelEmpty();
            veriYukle();
            oranYukle();
        }

        private void kayitSil_Click(object sender, EventArgs e)
        {
            try
            {
                string hataMesaji = null;
                Boolean deleteSuccessful = false;
                DialogResult yourChoice = new DialogResult();
                
                if (seciliDegisken.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğrenciyi seçtikten sonra silme işlemi gerçekleştiriniz","Seçim Yapılmamış",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
                    return;
                }

                yourChoice = MessageBox.Show(seciliDegisken.Text + " Tc Kimlik Numarali öğrenciyi silmek istediğinize emin misiniz? DİKKAT: EĞER BU KİŞİYİ SİLERSENİZ BU KİŞİYLE BAĞLANTILI TÜM İŞLEMLER(RAPORLAR, HESAPLAMALAR VB..) SİLİNECEK!!!!!!", "Öğrenci Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (yourChoice == DialogResult.Yes)
                {
                    deleteSuccessful = veriTabani.veriSil("Delete From Ogrenci where tckimlikNu like '" + seciliDegisken.Text + "'", ref hataMesaji);
                    if (deleteSuccessful)
                    {
                        dataGrid.DataSource = veriTabani.vtbaglan("Select Ogrenci.adi, Ogrenci.soyadi, Ogrenci.tckimlikNu, Ogrenci.iban, Kurumlar.kurumAdi, Ogrenci.oran, Ogrenci.aciklama from (Ogrenci INNER JOIN Kurumlar ON Ogrenci.okulu = Kurumlar.kurumid ) ORDER BY Ogrenci.adi ASC;");
                        MessageBox.Show("Kayıt silinmiştir", "Kayıt Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silme işleminde bir hata oluştu..." + Environment.NewLine + "HATA: " + hataMesaji, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata: " + hata);
            }
        }

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            seciliDegisken.Text = dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();//Bu değişkeni sabit değişken olarak tutmak için oluşturduğumuz bir label üzerine değer atayıp okuyarak kontrol ediyoruz. 
            adi.Text = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            soyadi.Text = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            tckimlikNu.Text = dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            iban.Text = dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            okulu.Text = dataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
            oran.Text = dataGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
            aciklama.Text = dataGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void kayitGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;
                DialogResult yourChoice = new DialogResult();

                yourChoice = MessageBox.Show(seciliDegisken.Text + " TC Kimlik Numaralı Öğrenciyi değiştirmek istediğinize emin misiniz? DİKKAT: EĞER BU ÖĞRENCİDE DEĞİŞİKLİK YAPARSANIZ BU KURUMLA BAĞLANTILI TÜM İŞLEMLER(PERSONELLER, HESAPLAMALAR VB..) ETKİLENECEKTİR!!!!!!", "Kurum Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                veriIdBul(okulu.Text);
                if (yourChoice == DialogResult.Yes)
                {
                    ; //Birşey yapma
                }
                else
                {
                    MessageBox.Show("Değişiklik işlemi iptal edildi", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Bu isimde bir kurum olup olmadığını kontrol ediyoruz
                kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from Ogrenci where tckimlikNu like '" + tckimlikNu.Text + "'", ref hataMesaji);
                if (boslukKontrol() != true) //Boşluk olup olmadığını kontrol eden method çağırılıyor
                {
                    MessageBox.Show("Boş alanlar tespit edildi. Lütfen tüm alanları eksiksiz doldurduktan sonra tekrar deneyiniz", "Boş Alan Tespit Edildi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (kayitVarmi != 0 && tckimlikNu.Text != seciliDegisken.Text)
                {
                    MessageBox.Show("Bu TC Kimlik Numarası ile daha önceden başka bir öğrenci kayıt edilmiş. Lütfen kontrol edip tekrar deneyiziniz", "Kayıt Tekrarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    veriTabani.veriGuncelle("UPDATE Ogrenci SET adi='" + adi.Text.Trim() + "', soyadi='" + soyadi.Text.Trim() + "', tckimlikNu='" + tckimlikNu.Text.Trim() + "', oran='" + oran.Text.Trim() + "', okulu=" + okulID + ", iban='" + iban.Text.Trim() + "', aciklama='" + aciklama.Text.Trim() + "' WHERE tckimlikNu='" + seciliDegisken.Text + "'", ref hataMesaji);
                }

                if (hataMesaji == String.Empty)
                {
                    MessageBox.Show("Kayıt Güncellenmiştir");

                    dataGrid.DataSource = veriTabani.vtbaglan("Select Ogrenci.adi, Ogrenci.soyadi, Ogrenci.tckimlikNu, Ogrenci.iban, Kurumlar.kurumAdi, Ogrenci.oran, Ogrenci.aciklama from (Ogrenci INNER JOIN Kurumlar ON Ogrenci.okulu = Kurumlar.kurumid ) ORDER BY Ogrenci.adi ASC;");
                    viewPanelEmpty(); //Textbox'ları temizliyoruz
                    veriYukle();
                    oranYukle();
                }
                else
                {
                    MessageBox.Show(hataMesaji);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata: " + hata);
            }
        }

        private void quickSearch_TextChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = veriTabani.vtbaglan("Select Ogrenci.adi, Ogrenci.soyadi, Ogrenci.tckimlikNu, Ogrenci.iban, Kurumlar.kurumAdi, Ogrenci.oran, Ogrenci.aciklama from (Ogrenci INNER JOIN Kurumlar ON Ogrenci.okulu = Kurumlar.kurumid ) WHERE (Ogrenci.adi like '%" + quickSearch.Text.TrimEnd() + "%') or (Ogrenci.soyadi like '%" + quickSearch.Text.TrimEnd() + "%') or (Ogrenci.tckimlikNu like '%" + quickSearch.Text.TrimEnd() + "%') ORDER BY Ogrenci.adi ASC;");            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            quickSearch.Text = string.Empty;
            viewPanelEmpty(); //Textbox'ları temizliyoruz
            veriYukle();  //Kadro durumunu checkbox'a yeniden yüklüyoruz. 
            oranYukle();  //10 a kadar oran checkbox'ı dolduruyoruz. 
        }

        private void Ogrenciler_Resize(object sender, EventArgs e)
        {
            yeniBoyut(); //Formun boyutu değiştikçe nesnelerin pozisyonları ve yerleri ayarlanıyor. 
        }
    }
}
