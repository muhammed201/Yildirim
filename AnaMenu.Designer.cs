namespace Yildirim
{
    partial class AnaMenu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kayıtİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurumKaydıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelKaydıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öğrenciKaydıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanımlamaİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idariGörevTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilgiliYılTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modüllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesaplamaVeGenelDağıtımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oranTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kayıtİşlemleriToolStripMenuItem,
            this.tanımlamaİşlemleriToolStripMenuItem,
            this.modüllerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kayıtİşlemleriToolStripMenuItem
            // 
            this.kayıtİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kurumKaydıToolStripMenuItem,
            this.personelKaydıToolStripMenuItem,
            this.öğrenciKaydıToolStripMenuItem});
            this.kayıtİşlemleriToolStripMenuItem.Name = "kayıtİşlemleriToolStripMenuItem";
            this.kayıtİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.kayıtİşlemleriToolStripMenuItem.Text = "Kayıt İşlemleri";
            // 
            // kurumKaydıToolStripMenuItem
            // 
            this.kurumKaydıToolStripMenuItem.Name = "kurumKaydıToolStripMenuItem";
            this.kurumKaydıToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.kurumKaydıToolStripMenuItem.Text = "Okul/Kurum Kaydı";
            this.kurumKaydıToolStripMenuItem.Click += new System.EventHandler(this.kurumKaydıToolStripMenuItem_Click);
            // 
            // personelKaydıToolStripMenuItem
            // 
            this.personelKaydıToolStripMenuItem.Name = "personelKaydıToolStripMenuItem";
            this.personelKaydıToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.personelKaydıToolStripMenuItem.Text = "Personel Kaydı";
            this.personelKaydıToolStripMenuItem.Click += new System.EventHandler(this.personelKaydıToolStripMenuItem_Click);
            // 
            // öğrenciKaydıToolStripMenuItem
            // 
            this.öğrenciKaydıToolStripMenuItem.Name = "öğrenciKaydıToolStripMenuItem";
            this.öğrenciKaydıToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.öğrenciKaydıToolStripMenuItem.Text = "Öğrenci Kaydı";
            this.öğrenciKaydıToolStripMenuItem.Click += new System.EventHandler(this.öğrenciKaydıToolStripMenuItem_Click);
            // 
            // tanımlamaİşlemleriToolStripMenuItem
            // 
            this.tanımlamaİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idariGörevTanımlamaToolStripMenuItem,
            this.ilgiliYılTanımlamaToolStripMenuItem,
            this.oranTanımlamaToolStripMenuItem});
            this.tanımlamaİşlemleriToolStripMenuItem.Name = "tanımlamaİşlemleriToolStripMenuItem";
            this.tanımlamaİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.tanımlamaİşlemleriToolStripMenuItem.Text = "Tanımlama İşlemleri";
            // 
            // idariGörevTanımlamaToolStripMenuItem
            // 
            this.idariGörevTanımlamaToolStripMenuItem.Name = "idariGörevTanımlamaToolStripMenuItem";
            this.idariGörevTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.idariGörevTanımlamaToolStripMenuItem.Text = "Görev/Ünvan/Alan/Bölüm Tanımlama";
            this.idariGörevTanımlamaToolStripMenuItem.Click += new System.EventHandler(this.idariGörevTanımlamaToolStripMenuItem_Click);
            // 
            // ilgiliYılTanımlamaToolStripMenuItem
            // 
            this.ilgiliYılTanımlamaToolStripMenuItem.Name = "ilgiliYılTanımlamaToolStripMenuItem";
            this.ilgiliYılTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.ilgiliYılTanımlamaToolStripMenuItem.Text = "İlgili Yıl Tanımlama";
            this.ilgiliYılTanımlamaToolStripMenuItem.Click += new System.EventHandler(this.ilgiliYılTanımlamaToolStripMenuItem_Click);
            // 
            // modüllerToolStripMenuItem
            // 
            this.modüllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hesaplamaVeGenelDağıtımToolStripMenuItem});
            this.modüllerToolStripMenuItem.Name = "modüllerToolStripMenuItem";
            this.modüllerToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.modüllerToolStripMenuItem.Text = "Modüller";
            // 
            // hesaplamaVeGenelDağıtımToolStripMenuItem
            // 
            this.hesaplamaVeGenelDağıtımToolStripMenuItem.Name = "hesaplamaVeGenelDağıtımToolStripMenuItem";
            this.hesaplamaVeGenelDağıtımToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.hesaplamaVeGenelDağıtımToolStripMenuItem.Text = "Hesaplama ve Genel Dağıtım";
            this.hesaplamaVeGenelDağıtımToolStripMenuItem.Click += new System.EventHandler(this.hesaplamaVeGenelDağıtımToolStripMenuItem_Click);
            // 
            // oranTanımlamaToolStripMenuItem
            // 
            this.oranTanımlamaToolStripMenuItem.Name = "oranTanımlamaToolStripMenuItem";
            this.oranTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.oranTanımlamaToolStripMenuItem.Text = "Oran Tanımlama";
            this.oranTanımlamaToolStripMenuItem.Click += new System.EventHandler(this.oranTanımlamaToolStripMenuItem_Click);
            // 
            // AnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yıldırım 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kayıtİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kurumKaydıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelKaydıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öğrenciKaydıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanımlamaİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idariGörevTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ilgiliYılTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modüllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hesaplamaVeGenelDağıtımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oranTanımlamaToolStripMenuItem;
    }
}

