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
    public partial class kelola : Form
    {
        public kelola()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2ComboBox1.Text == "" )
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
                string nis = guna2TextBox4.Text;
                string kelas = guna2TextBox5.Text;
                string jurusan = guna2ComboBox2.Text;
                string nohp = guna2TextBox7.Text;
                string alamat = guna2TextBox8.Text;

                DB.crud($"INSERT INTO users VALUES (null,'{un}','{pw}','{rl}')");

                DB.crud($"INSERT INTO siswa VALUES (null,LAST_INSERT_ID(),'{nis}','{nama}','{kelas}','{jurusan}','{nohp}','{alamat}')");
                tampil();
                bersih();
            }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void kelola_Load(object sender, EventArgs e)
        {
            tampil();
            guna2TextBox1.Select();
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
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2ComboBox2.SelectedIndex = -1;
        }

        public void tampil()
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"Select * FROM `users` inner join siswa on users.id_user = siswa.id_user");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_siswa"];
                string idu = "" + baris["id_siswa"];
                string nama = "" + baris["nama_siswa"];
                string role = "" + baris["role"];
                string kelas = "" + baris["kelas"];
                string jurusan = "" + baris["jurusan"];

                guna2DataGridView1.Rows.Add(id, idu, nama, role, kelas, jurusan);
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
                string jurusan = guna2ComboBox2.Text;
                string nohp = guna2TextBox7.Text;
                string alamat = guna2TextBox8.Text;
                DB.crud($"UPDATE `users` SET `role`='{role}' where id_user = '{id}'");
                DB.crud($"UPDATE `siswa` SET `nama_siswa`='{nama}', `nis`='{nis}',`kelas`='{kelas}',`jurusan`='{jurusan}',`no_hp`='{nohp}',`alamat`='{alamat}' where id_user = '{id}'");
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
            string id = guna2DataGridView1.Rows[baris].Cells[1].Value.ToString();
            string namaa = guna2DataGridView1.Rows[baris].Cells[2].Value.ToString();
            if (kolom == 6)
            {

                DB.crud($"Select * FROM `users` inner join siswa on users.id_user = siswa.id_user where id_siswa = '{idnya}'");
                foreach (DataRow bariss in DB.ds.Tables[0].Rows)
                {
                    string idu = "" + bariss["id_user"];
                    string nama = "" + bariss["nama_siswa"];
                    string Role = "" + bariss["Role"];
                    string nis = "" + bariss["nis"];
                    string kelas = "" + bariss["kelas"];
                    string jr = "" + bariss["jurusan"];
                    string no = "" + bariss["no_hp"];
                    string alamat = "" + bariss["alamat"];

                    label5.Text = idu;
                    guna2TextBox1.Text = nama;
                    guna2TextBox2.Text = "********";
                    guna2TextBox3.Text = "********";
                    guna2ComboBox1.Text = Role;
                    guna2TextBox4.Text = nis;
                    guna2TextBox5.Text = kelas;
                    guna2ComboBox2.Text = jr;
                    guna2TextBox7.Text = no;
                    guna2TextBox8.Text = alamat;

                }
                guna2Button4.Visible = true;
                guna2TextBox2.Enabled = false;
                guna2TextBox3.Enabled = false;
                guna2Button1.Visible = false;
                guna2Button2.Visible = true;
            }
            if (kolom == 7)
            {
                DialogResult setuju = MessageBox.Show("Apakah kamu ingin menghapus " + namaa + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"delete from users where id_user = '{id}'");
                    DB.crud($"delete from siswa where id_siswa = '{idnya}'");
                    guna2DataGridView1.Rows.Clear();
                    tampil();
                }
            }
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2TextBox2.Select();
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2TextBox3.Select();
            }
        }

        private void guna2TextBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2ComboBox1.Select();
            }
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

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            tampil();
        }

        private void guna2TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
