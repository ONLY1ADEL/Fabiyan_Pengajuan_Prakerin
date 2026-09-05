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
    public partial class SPengajuan : Form
    {
        public SPengajuan()
        {
            InitializeComponent();
        }
        public string ids;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nama = guna2TextBox1.Text;
            string nh = guna2TextBox3.Text;
            string em = guna2TextBox2.Text;
            string al = richTextBox1.Text;
            string id = ids;
            string tm = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string ts = guna2DateTimePicker2.Value.ToString("yyyy-MM-dd");
            string tp = DateTime.Now.ToString("yyyy-MM-dd");

            DB.crud($"INSERT INTO perusahaan VALUES (null,'{nama}','{al}','{nh}','{em}')");

            DB.crud($"INSERT INTO pengajuan_prakerin VALUES (null,'{id}',LAST_INSERT_ID(),'{tp}','{tm}','{ts}','{"Menunggu"}')");

            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
            guna2TextBox6.Clear();
            richTextBox1.Clear();

        }

        private void SPengajuan_Load(object sender, EventArgs e)
        {

            DB.crud($"Select * FROM siswa where id_siswa = '{ids}'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string nama = "" + baris["nama_siswa"];
                string kelas = "" + baris["kelas"];
                guna2TextBox6.Text = nama;
                guna2TextBox4.Text = kelas;
            }
        }
    }
}
