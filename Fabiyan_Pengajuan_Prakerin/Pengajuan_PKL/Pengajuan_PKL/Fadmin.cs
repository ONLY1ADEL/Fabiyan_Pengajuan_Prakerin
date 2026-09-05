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
    public partial class Fadmin : Form
    {
        public Fadmin()
        {
            InitializeComponent();
        }
        public string ida;

        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            kelola h = new kelola() { TopLevel = false, TopMost = true }; ;
            kf.untukformfabiyan(h, panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            kelolaguru a = new kelolaguru() { TopLevel = false, TopMost = true }; ;
            kf.untukformfabiyan(a, panel1);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            kelolaperusahaan b = new kelolaperusahaan() { TopLevel = false, TopMost = true }; ;
            kf.untukformfabiyan(b, panel1);
        }
    }
}
