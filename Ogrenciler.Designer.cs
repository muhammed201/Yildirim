namespace Yildirim
{
    partial class Ogrenciler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ogrenciler));
            this.dataGridPanel = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.refresh = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.quickSearch = new System.Windows.Forms.TextBox();
            this.seciliDegisken = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.oran = new System.Windows.Forms.ComboBox();
            this.okulu = new System.Windows.Forms.ComboBox();
            this.temizle = new System.Windows.Forms.Button();
            this.kayitSil = new System.Windows.Forms.Button();
            this.kayitGuncelle = new System.Windows.Forms.Button();
            this.kayitEkle = new System.Windows.Forms.Button();
            this.aciklama = new System.Windows.Forms.TextBox();
            this.iban = new System.Windows.Forms.TextBox();
            this.tckimlikNu = new System.Windows.Forms.TextBox();
            this.soyadi = new System.Windows.Forms.TextBox();
            this.adi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.viewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.AutoSize = true;
            this.dataGridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridPanel.Controls.Add(this.dataGrid);
            this.dataGridPanel.Location = new System.Drawing.Point(38, 265);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Size = new System.Drawing.Size(881, 350);
            this.dataGridPanel.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGrid.ColumnHeadersHeight = 42;
            this.dataGrid.Location = new System.Drawing.Point(6, 2);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(870, 343);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_RowEnter);
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refresh.BackgroundImage")));
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh.Location = new System.Drawing.Point(319, 234);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(32, 29);
            this.refresh.TabIndex = 17;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(48, 241);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "Hızlı Arama";
            // 
            // quickSearch
            // 
            this.quickSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.quickSearch.Location = new System.Drawing.Point(138, 238);
            this.quickSearch.Name = "quickSearch";
            this.quickSearch.Size = new System.Drawing.Size(178, 22);
            this.quickSearch.TabIndex = 15;
            this.quickSearch.TextChanged += new System.EventHandler(this.quickSearch_TextChanged);
            // 
            // seciliDegisken
            // 
            this.seciliDegisken.AutoSize = true;
            this.seciliDegisken.Location = new System.Drawing.Point(39, 3);
            this.seciliDegisken.Name = "seciliDegisken";
            this.seciliDegisken.Size = new System.Drawing.Size(58, 13);
            this.seciliDegisken.TabIndex = 19;
            this.seciliDegisken.Text = "Seçili Kayıt";
            // 
            // viewPanel
            // 
            this.viewPanel.AutoScroll = true;
            this.viewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewPanel.Controls.Add(this.oran);
            this.viewPanel.Controls.Add(this.okulu);
            this.viewPanel.Controls.Add(this.temizle);
            this.viewPanel.Controls.Add(this.kayitSil);
            this.viewPanel.Controls.Add(this.kayitGuncelle);
            this.viewPanel.Controls.Add(this.kayitEkle);
            this.viewPanel.Controls.Add(this.aciklama);
            this.viewPanel.Controls.Add(this.iban);
            this.viewPanel.Controls.Add(this.tckimlikNu);
            this.viewPanel.Controls.Add(this.soyadi);
            this.viewPanel.Controls.Add(this.adi);
            this.viewPanel.Controls.Add(this.label15);
            this.viewPanel.Controls.Add(this.label8);
            this.viewPanel.Controls.Add(this.label6);
            this.viewPanel.Controls.Add(this.label5);
            this.viewPanel.Controls.Add(this.label3);
            this.viewPanel.Controls.Add(this.label2);
            this.viewPanel.Controls.Add(this.label1);
            this.viewPanel.Location = new System.Drawing.Point(38, 21);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(877, 217);
            this.viewPanel.TabIndex = 20;
            // 
            // oran
            // 
            this.oran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oran.FormattingEnabled = true;
            this.oran.Location = new System.Drawing.Point(468, 99);
            this.oran.Name = "oran";
            this.oran.Size = new System.Drawing.Size(75, 28);
            this.oran.TabIndex = 6;
            // 
            // okulu
            // 
            this.okulu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.okulu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.okulu.FormattingEnabled = true;
            this.okulu.Location = new System.Drawing.Point(468, 59);
            this.okulu.Name = "okulu";
            this.okulu.Size = new System.Drawing.Size(224, 28);
            this.okulu.TabIndex = 5;
            // 
            // temizle
            // 
            this.temizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.temizle.ForeColor = System.Drawing.Color.SteelBlue;
            this.temizle.Location = new System.Drawing.Point(437, 160);
            this.temizle.Name = "temizle";
            this.temizle.Size = new System.Drawing.Size(134, 36);
            this.temizle.TabIndex = 11;
            this.temizle.Text = "Temizle";
            this.temizle.UseVisualStyleBackColor = true;
            this.temizle.Click += new System.EventHandler(this.temizle_Click);
            // 
            // kayitSil
            // 
            this.kayitSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayitSil.ForeColor = System.Drawing.Color.SteelBlue;
            this.kayitSil.Location = new System.Drawing.Point(297, 160);
            this.kayitSil.Name = "kayitSil";
            this.kayitSil.Size = new System.Drawing.Size(134, 36);
            this.kayitSil.TabIndex = 10;
            this.kayitSil.Text = "Kayıt Sil";
            this.kayitSil.UseVisualStyleBackColor = true;
            this.kayitSil.Click += new System.EventHandler(this.kayitSil_Click);
            // 
            // kayitGuncelle
            // 
            this.kayitGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayitGuncelle.ForeColor = System.Drawing.Color.SteelBlue;
            this.kayitGuncelle.Location = new System.Drawing.Point(157, 160);
            this.kayitGuncelle.Name = "kayitGuncelle";
            this.kayitGuncelle.Size = new System.Drawing.Size(134, 36);
            this.kayitGuncelle.TabIndex = 9;
            this.kayitGuncelle.Text = "Güncelle";
            this.kayitGuncelle.UseVisualStyleBackColor = true;
            this.kayitGuncelle.Click += new System.EventHandler(this.kayitGuncelle_Click);
            // 
            // kayitEkle
            // 
            this.kayitEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayitEkle.ForeColor = System.Drawing.Color.SteelBlue;
            this.kayitEkle.Location = new System.Drawing.Point(17, 160);
            this.kayitEkle.Name = "kayitEkle";
            this.kayitEkle.Size = new System.Drawing.Size(134, 36);
            this.kayitEkle.TabIndex = 8;
            this.kayitEkle.Text = "Kayıt Ekle";
            this.kayitEkle.UseVisualStyleBackColor = true;
            this.kayitEkle.Click += new System.EventHandler(this.kayitEkle_Click);
            // 
            // aciklama
            // 
            this.aciklama.Location = new System.Drawing.Point(603, 120);
            this.aciklama.MaxLength = 250;
            this.aciklama.Multiline = true;
            this.aciklama.Name = "aciklama";
            this.aciklama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.aciklama.Size = new System.Drawing.Size(241, 76);
            this.aciklama.TabIndex = 7;
            // 
            // iban
            // 
            this.iban.Location = new System.Drawing.Point(468, 22);
            this.iban.MaxLength = 26;
            this.iban.Name = "iban";
            this.iban.Size = new System.Drawing.Size(224, 20);
            this.iban.TabIndex = 4;
            // 
            // tckimlikNu
            // 
            this.tckimlikNu.Location = new System.Drawing.Point(108, 97);
            this.tckimlikNu.MaxLength = 11;
            this.tckimlikNu.Name = "tckimlikNu";
            this.tckimlikNu.Size = new System.Drawing.Size(183, 20);
            this.tckimlikNu.TabIndex = 3;
            // 
            // soyadi
            // 
            this.soyadi.Location = new System.Drawing.Point(108, 61);
            this.soyadi.MaxLength = 50;
            this.soyadi.Name = "soyadi";
            this.soyadi.Size = new System.Drawing.Size(183, 20);
            this.soyadi.TabIndex = 2;
            // 
            // adi
            // 
            this.adi.Location = new System.Drawing.Point(108, 28);
            this.adi.MaxLength = 50;
            this.adi.Name = "adi";
            this.adi.Size = new System.Drawing.Size(183, 20);
            this.adi.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(600, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Açıklama";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(393, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "IBAN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(393, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Okulu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(393, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Oran";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tc Kimlik Nu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyadı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adı";
            // 
            // Ogrenciler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 652);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.seciliDegisken);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.quickSearch);
            this.Controls.Add(this.dataGridPanel);
            this.Name = "Ogrenciler";
            this.Text = "Ogrenciler";
            this.Load += new System.EventHandler(this.Ogrenciler_Load);
            this.Resize += new System.EventHandler(this.Ogrenciler_Resize);
            this.dataGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.viewPanel.ResumeLayout(false);
            this.viewPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dataGridPanel;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox quickSearch;
        private System.Windows.Forms.Label seciliDegisken;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.ComboBox oran;
        private System.Windows.Forms.ComboBox okulu;
        private System.Windows.Forms.Button temizle;
        private System.Windows.Forms.Button kayitSil;
        private System.Windows.Forms.Button kayitGuncelle;
        private System.Windows.Forms.Button kayitEkle;
        private System.Windows.Forms.TextBox aciklama;
        private System.Windows.Forms.TextBox iban;
        private System.Windows.Forms.TextBox tckimlikNu;
        private System.Windows.Forms.TextBox soyadi;
        private System.Windows.Forms.TextBox adi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}