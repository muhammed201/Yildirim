using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Yildirim
{
    public partial class Kurumlar : Form
    {
        double oranW, oranH;
        public Kurumlar()
        {
            InitializeComponent();
        }

        public void yeniBoyut()
        {
            int sizeW = Convert.ToInt32(this.Size.Width * oranW);
            int sizeH = Convert.ToInt32(this.Size.Height * oranH);
            dataGridPanel.Size = new Size(sizeW, sizeH);            
            dataGrid.Size = new Size(sizeW-10, sizeH-10);            
        }

        void dataGridCaption()
        {
            dataGrid.Columns[0].HeaderText = "Kurum Adı";            
            dataGrid.Columns[1].HeaderText = "İl";
            dataGrid.Columns[2].HeaderText = "İlçe";            
            dataGrid.Columns[3].HeaderText = "Kuruluş Tarihi";            
            dataGrid.Columns[4].HeaderText = "Dose Kodu";            
            dataGrid.Columns[5].HeaderText = "Vergi Kimlik Nu";            
            dataGrid.Columns[6].HeaderText = "Banka";            
            dataGrid.Columns[7].HeaderText = "İban Nu";            
            dataGrid.Columns[8].HeaderText = "Adres";            
            dataGrid.Columns[9].HeaderText = "Telefon";            
            dataGrid.Columns[10].HeaderText = "E-posta";            
            dataGrid.Columns[11].HeaderText = "Ebyn Kodu";            
            dataGrid.Columns[12].HeaderText = "Sermaye Tutarı";            
            dataGrid.Columns[13].HeaderText = "Kurum Kodu";            
            dataGrid.Columns[14].HeaderText = "Açıklama";            
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
            }
            seciliDegisken.Text = string.Empty;
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

        void replaceMobile()
        {         
            telefon.Text = Regex.Replace(telefon.Text, @"(\d{3})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4");
        }
        private void Kurumlar_Resize(object sender, EventArgs e)
        {
            yeniBoyut(); //Formun boyutu değiştikçe nesnelerin pozisyonları ve yerleri ayarlanıyor. 
        }

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            seciliDegisken.Text = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();//Bu değişkeni sabit değişken olarak tutmak için oluşturduğumuz bir label üzerine değer atayıp okuyarak kontrol ediyoruz. 
            kurumAdi.Text=dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            il.Text = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            ilce.Text = dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            kurulusTarihi.Text = dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            doseKodu.Text = dataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
            vergiKimlikNu.Text = dataGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
            banka.Text = dataGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
            iban.Text = dataGrid.Rows[e.RowIndex].Cells[7].Value.ToString();
            adres.Text = dataGrid.Rows[e.RowIndex].Cells[8].Value.ToString();
            telefon.Text = dataGrid.Rows[e.RowIndex].Cells[9].Value.ToString();
            eposta.Text = dataGrid.Rows[e.RowIndex].Cells[10].Value.ToString();
            ebynKodu.Text = dataGrid.Rows[e.RowIndex].Cells[11].Value.ToString();
            sermayeTutari.Text = dataGrid.Rows[e.RowIndex].Cells[12].Value.ToString();
            kurumKodu.Text = dataGrid.Rows[e.RowIndex].Cells[13].Value.ToString();
            aciklama.Text = dataGrid.Rows[e.RowIndex].Cells[14].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            viewPanelEmpty();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;

                //Bu isimde bir kurum olup olmadığını kontrol ediyoruz
                kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from Kurumlar where kurumAdi like '" + kurumAdi.Text + "'", ref hataMesaji);
                if (boslukKontrol() != true) //Boşluk olup olmadığını kontrol eden method çağırılıyor
                {
                    MessageBox.Show("Boş alanlar tespit edildi. Lütfen tüm alanları eksiksiz doldurduktan sonra tekrar deneyiniz", "Boş Alan Tespit Edildi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                else if (kayitVarmi != 0)
                {
                    MessageBox.Show("Bu isim ile daha önceden başka bir kurum kayıt edilmiş. Lütfen kontrol edip tekrar deneyiziniz", "Kayıt Tekrarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    veriTabani.veriEkle("INSERT INTO Kurumlar (kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama) VALUES ('" + kurumAdi.Text.Trim() + "','" + il.Text.Trim() + "','" + ilce.Text.Trim() + "','" + kurulusTarihi.Text.Trim() + "','" + doseKodu.Text.Trim() + "','" + vergiKimlikNu.Text.Trim() + "','" + banka.Text.Trim() + "','" + iban.Text.Trim() + "','" + adres.Text.Trim() + "','" + telefon.Text.Trim() + "','" + eposta.Text.Trim() + "','" + ebynKodu.Text.Trim() + "','" + sermayeTutari.Text.Trim() + "','" + kurumKodu.Text.Trim() + "','" + aciklama.Text.Trim() + "');", ref hataMesaji);
                }

                if (hataMesaji == String.Empty)
                {
                    MessageBox.Show("Kayıt başarılı");

                    dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar ORDER BY kurumAdi ASC;");
                    viewPanelEmpty(); //Textbox'ları temizliyoruz
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

        private void kayitGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string hataMesaji = string.Empty;
                int kayitVarmi;
                DialogResult yourChoice = new DialogResult();

                yourChoice = MessageBox.Show(seciliDegisken.Text + " kurumunu değiştirmek istediğinize emin misiniz? DİKKAT: EĞER BU KURUMDA DEĞİŞİKLİK YAPARSANIZ BU KURUMLA BAĞLANTILI TÜM İŞLEMLER(PERSONELLER, HESAPLAMALAR VB..) ETKİLENECEKTİR!!!!!!", "Kurum Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                    kayitVarmi = veriTabani.kullaniciSayisi("Select COUNT(*) from Kurumlar where kurumAdi like '" + kurumAdi.Text + "'", ref hataMesaji);
                if (boslukKontrol() != true) //Boşluk olup olmadığını kontrol eden method çağırılıyor
                {
                    MessageBox.Show("Boş alanlar tespit edildi. Lütfen tüm alanları eksiksiz doldurduktan sonra tekrar deneyiniz", "Boş Alan Tespit Edildi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (kayitVarmi != 0 && kurumAdi.Text!=seciliDegisken.Text)
                {
                    MessageBox.Show("Bu isim ile daha önceden başka bir kurum kayıt edilmiş. Lütfen kontrol edip tekrar deneyiziniz", "Kayıt Tekrarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    veriTabani.veriGuncelle("UPDATE Kurumlar SET kurumAdi='" + kurumAdi.Text.Trim() + "', il='" + il.Text.Trim() + "', ilce='" + ilce.Text.Trim() + "', kurulusTarihi='" + kurulusTarihi.Text.Trim() + "', doseKodu='" + doseKodu.Text.Trim() + "', vergiKimlikNu='" + vergiKimlikNu.Text.Trim() + "', banka='" + banka.Text.Trim() +"', iban='" + iban.Text.Trim() + "', adres='" + adres.Text.Trim() + "', telefon='" + telefon.Text.Trim() + "', eposta='" + eposta.Text.Trim() + "', ebynKodu='" + ebynKodu.Text.Trim() + "', sermayeTutari='" + sermayeTutari.Text.Trim() + "', kurumKodu='" + kurumKodu.Text.Trim() + "', aciklama='" + aciklama.Text.Trim() + "' WHERE kurumAdi='" +seciliDegisken.Text + "'", ref hataMesaji);
                    //veriTabani.veriGuncelle("UPDATE staff SET registration='" + registration.Text.Trim() + "', stafName='" + stafName.Text.Trim() + "', stafSurname='" + stafSurname.Text.Trim() + "', duty='" + gDutyId + "', department='" + gDepartmentId + "', mobilephone='" + mobilephone.Text + "', internalphone='" + internalphone.Text.Trim() + "', tempDepartment='" + tempDepartment.Text.Trim() + "', note='" + note.Text.Trim() + "', stafflog= CONCAT(stafflog, ' ', ' log:" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + " Tarihinde " + genel.enterUserName + " tarafından güncellendi.') WHERE registration='" + staffGroupBox.Text + "'", ref hataMesaji);
                }

                if (hataMesaji == String.Empty)
                {
                    MessageBox.Show("Kayıt Güncellenmiştir");

                    dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar ORDER BY kurumAdi ASC;");
                    viewPanelEmpty(); //Textbox'ları temizliyoruz
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            kurulusTarihi.Text = monthCalendar1.SelectionStart.ToString("dd.MM.yyyy");
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
        }

        private void kurulusTarihi_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void kayitSil_Click(object sender, EventArgs e)
        {
            try
            {                
                string hataMesaji = null;
                Boolean deleteSuccessful = false;
                DialogResult yourChoice = new DialogResult();                

                yourChoice = MessageBox.Show(seciliDegisken.Text + " kurumunu silmek istediğinize emin misiniz? DİKKAT: EĞER BU KURUMU SİLERSENİZ BU KURUMLA BAĞLANTILI TÜM İŞLEMLER(PERSONELLER, HESAPLAMALAR VB..) SİLİNECEK!!!!!!", "Kurum Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (yourChoice == DialogResult.Yes)
                {
                    deleteSuccessful = veriTabani.veriSil("Delete From Kurumlar where kurumAdi like '" + seciliDegisken.Text + "'", ref hataMesaji);
                    if (deleteSuccessful)
                    {
                        dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar ORDER BY kurumAdi ASC;");
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

        private void refresh_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar ORDER BY kurumAdi ASC;");
            quickSearch.Text = null;
            viewPanelEmpty(); //Textbox'ları temizliyoruz
        }

        private void quickSearch_TextChanged(object sender, EventArgs e)
        {            
            dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar WHERE (kurumAdi like '%" + quickSearch.Text.TrimEnd() + "%') ORDER BY kurumAdi ASC;");
        }

        private void telefon_Leave(object sender, EventArgs e)
        {
            replaceMobile(); //Telefon numarası formatını ayarlıyoruz.
        }

        private void kurulusTarihi_Leave(object sender, EventArgs e)
        {
            monthCalendar1.Visible=false;
        }

        private void Kurumlar_Load(object sender, EventArgs e)
        {
            dataGrid.DataSource = veriTabani.vtbaglan("Select kurumAdi, il, ilce, kurulusTarihi, doseKodu, vergiKimlikNu, banka, iban, adres, telefon, eposta, ebynKodu, sermayeTutari, kurumKodu, aciklama from Kurumlar ORDER BY kurumAdi ASC;");
            dataGridCaption(); //DataGridview başlıkları ayarlanıyor.
            
            //Açılış değerlerini alıyor. Daha sonra yeniBoyut() fonksiyonu ile formun boyutu değiştikçe nesnelerin pozisyonları ve yerleri ayarlanıyor. 
            oranW = (double)dataGridPanel.Size.Width / (double)this.Size.Width;
            oranH = (double)dataGridPanel.Size.Height / (double)this.Size.Height;
            dataGrid.ScrollBars = ScrollBars.Both;
        }
    }
}
