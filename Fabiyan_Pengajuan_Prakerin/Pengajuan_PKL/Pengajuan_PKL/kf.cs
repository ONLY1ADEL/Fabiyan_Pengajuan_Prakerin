using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pengajuan_PKL
{
    class kf
    {
        public static void untukformfabiyan(Form formap, Panel panelap)
        {
            panelap.Controls.Clear();
            panelap.Controls.Add(formap);
            formap.FormBorderStyle = FormBorderStyle.None;
            formap.Dock = DockStyle.Fill;
            formap.Show();
        }
    }
}
