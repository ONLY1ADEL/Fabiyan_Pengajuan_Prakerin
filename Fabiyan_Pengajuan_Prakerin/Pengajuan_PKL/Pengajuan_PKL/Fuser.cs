using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pengajuan_PKL
{
    public partial class Fuser : Form
    {
        public Fuser()
        {
            InitializeComponent();
        }
        public String idu;

        private void Fuser_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SPengajuan h = new SPengajuan() { TopLevel = false, TopMost = true };
            h.ids = idu;
            kf.untukformfabiyan(h, panel1);
        }
    }
}
