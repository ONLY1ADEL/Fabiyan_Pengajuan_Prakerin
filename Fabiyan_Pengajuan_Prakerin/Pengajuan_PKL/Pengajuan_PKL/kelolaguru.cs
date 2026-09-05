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
    public partial class kelolaguru : Form
    {
        public kelolaguru()
        {
            InitializeComponent();
        }

        private void kelolaguru_Load(object sender, EventArgs e)
        {
            tampil();
            guna2TextBox1.Select();
        }
        public void tampil()
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"Select * FROM `users` inner join guru on users.id_user = guru.id_user");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_guru"];
                string idu = "" + baris["id_user"];
                string nama = "" + baris["nama_guru"];
                string role = "" + baris["role"];

                guna2DataGridView1.Rows.Add(id, idu, nama, role);
            }
        }

        public void bersih()
        {
            label5.Text = "";
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2ComboBox1.SelectedIndex = -1;
            guna2TextBox4.Clear();
            guna2TextBox5.Clear();  
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2ComboBox1.Text == "")
            {
                MessageBox.Show("Harap Isi Yang Kosong");
            }
            if (label5.Text != "")
            {

            }
            else
            {
                string nama = guna2TextBox1.Text;
                string un = guna2TextBox2.Text;
                string pw = guna2TextBox3.Text;
                string rl = guna2ComboBox1.Text;
                string nip = guna2TextBox4.Text;
                string no = guna2TextBox5.Text;

                DB.crud($"INSERT INTO users VALUES (null,'{un}','{pw}','{rl}')");

                DB.crud($"INSERT INTO guru VALUES (null,LAST_INSERT_ID(),'{nip}','{nama}','{no}')");
                tampil();
                bersih();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2ComboBox1.Text == "")
            {
                MessageBox.Show("Harap Isi Yang Kosong");
            }
            else
            {
                string id = label5.Text;
                string nama = guna2TextBox1.Text;
                string role = guna2ComboBox1.Text;
                string nis = guna2TextBox4.Text;
                string kelas = guna2TextBox5.Text;
                DB.crud($"UPDATE `users` SET `role`='{role}' where id_user = '{id}'");
                DB.crud($"UPDATE `guru` SET `nama_guru`='{nama}', `nip`='{nis}',`no_hp`='{kelas}' where id_user = '{id}'");
                tampil();
                bersih();
                guna2Button1.Visible = true;
                guna2Button2.Visible = false;
                guna2Button4.Visible = false;
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox2.Enabled = true;
                guna2TextBox3.Enabled = true;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button4.Visible = false;
            guna2TextBox2.Enabled = true;
            guna2TextBox3.Enabled = true;
            guna2Button1.Visible = true;
            guna2Button2.Visible = false;
            label5.Text = "";
            bersih();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
            string id = guna2DataGridView1.Rows[baris].Cells[1].Value.ToString();
            string namaa = guna2DataGridView1.Rows[baris].Cells[2].Value.ToString();
            if (kolom == 4)
            {

                DB.crud($"Select * FROM `users` inner join guru on users.id_user = guru.id_user where id_guru = '{idnya}'");
                foreach (DataRow bariss in DB.ds.Tables[0].Rows)
                {
                    string idu = "" + bariss["id_user"];
                    string nama = "" + bariss["nama_guru"];
                    string Role = "" + bariss["Role"];
                    string nis = "" + bariss["nip"];
                    string kelas = "" + bariss["no_hp"];

                    label5.Text = idu;
                    guna2TextBox1.Text = nama;
                    guna2TextBox2.Text = "********";
                    guna2TextBox3.Text = "********";
                    guna2ComboBox1.Text = Role;
                    guna2TextBox4.Text = nis;
                    guna2TextBox5.Text = kelas;

                }
                guna2Button4.Visible = true;
                guna2TextBox2.Enabled = false;
                guna2TextBox3.Enabled = false;
                guna2Button1.Visible = false;
                guna2Button2.Visible = true;
            }
            if (kolom == 5)
            {
                DialogResult setuju = MessageBox.Show("Apakah kamu ingin menghapus " + namaa + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"delete from users where id_user = '{id}'");
                    DB.crud($"delete from siswa where id_guru = '{idnya}'");
                    guna2DataGridView1.Rows.Clear();
                    tampil();
                }
            }
        }
    }
}
