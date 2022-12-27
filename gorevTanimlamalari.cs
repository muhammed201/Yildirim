using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Yildirim
{
    public partial class gorevTanimlamalari : Form
    {
        public gorevTanimlamalari()
        {
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dataGridView0.DataSource = veriTabani.vtbaglan("Select gorev from idariGorev ORDER BY gorev ASC;");
            dataGridView0.Columns[0].HeaderText = "İdari Görev";
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = veriTabani.vtbaglan("Select unvan from idariUnvan ORDER BY unvan ASC;");
            dataGridView1.Columns[0].HeaderText = "İdari Ünvan";
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            dataGridView2.DataSource = veriTabani.vtbaglan("Select gorev from ogretmenGorev ORDER BY gorev ASC;");
            dataGridView2.Columns[0].HeaderText = "Öğretmen Görev";
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            dataGridView3.DataSource = veriTabani.vtbaglan("Select unvan from ogretmenUnvan ORDER BY unvan ASC;");
            dataGridView3.Columns[0].HeaderText = "Öğretmen Ünvan";
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            dataGridView4.DataSource = veriTabani.vtbaglan("Select alani from ogrenciAlani ORDER BY alani ASC;");
            dataGridView4.Columns[0].HeaderText = "Öğrenci Alan";
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            dataGridView5.DataSource = veriTabani.vtbaglan("Select kod, bolumler from Bolumler ORDER BY bolumler ASC;");
            dataGridView5.Columns[0].HeaderText = "Bölüm Kodu";
            dataGridView5.Columns[1].HeaderText = "Bölüm İsmi";
        }
    }
}
