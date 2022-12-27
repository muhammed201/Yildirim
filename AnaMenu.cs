using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yildirim
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        public void formAc(Type FormType)
        {
            var form = this.MdiChildren.SingleOrDefault(p => p.GetType() == FormType);
            if (form == null)
                form = (Form)Activator.CreateInstance(FormType);
            form.MdiParent = this;
            form.Show();
            form.Focus();
        }

        private void kurumKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {                       
            formAc(typeof(Kurumlar));
            this.LayoutMdi(MdiLayout.Cascade); //Açılan Child formları basamaklı şekilde alt alta açıyor.
            
        }

        private void personelKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(Personeller));
            this.LayoutMdi(MdiLayout.Cascade); //Açılan Child formları basamaklı şekilde alt alta açıyor.
        }

        private void öğrenciKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(Ogrenciler));
            this.LayoutMdi(MdiLayout.Cascade); //Açılan Child formları basamaklı şekilde alt alta açıyor.
        }

        private void idariGörevTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(gorevTanimlamalari));
            this.LayoutMdi(MdiLayout.Cascade); //Açılan Child formları basamaklı şekilde alt alta açıyor.
        }

        private void ilgiliYılTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(ilgiliYil));
            this.LayoutMdi(MdiLayout.Cascade); //Açılan Child formları basamaklı şekilde alt alta açıyor. 
        }

        private void hesaplamaVeGenelDağıtımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(hisseFormulu));
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void oranTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAc(typeof(Oranlar));
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}
