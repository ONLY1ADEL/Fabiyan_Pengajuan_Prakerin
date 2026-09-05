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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("HARAP ISI YANG KOSONG");
            }
            else
            {
                DB.crud($"select * from users where username ='{textBox1.Text}' and password='{textBox2.Text}'");
                int cek = DB.ds.Tables[0].Rows.Count;
                if (cek == 1)
                {
                    DB.crud($"SELECT * FROM `users` inner join siswa on users.id_user = siswa.id_user WHERE users.Username = '{textBox1.Text}' AND users.Password = '{textBox2.Text}'");
                    DataRow bariss = DB.ds.Tables[0].Rows[0];
                    string role = "" + bariss["role"];

                    if (role == "admin")
                    {
                        string id = "" + bariss["id_user"];
                        Fadmin z = new Fadmin();
                        z.ida = id;
                        z.Visible = true;
                        this.Hide();
                    }
                    if (role == "siswa")
                    {
                        string idlogin = "" + bariss["id_siswa"];
                        Fuser f = new Fuser();
                        f.idu = idlogin;
                        f.Visible = true;
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("salah");
                }   
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox1.Text != "")
                {
                    textBox2.Select();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox2.Text != "")
                {
                    button1.Select();
                }
            }
        }
    }
}
