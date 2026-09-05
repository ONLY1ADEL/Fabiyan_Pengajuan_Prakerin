using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace Pengajuan_PKL
{
    class DB
    {
        public static MySqlConnection koneksi = new MySqlConnection("server=127.0.0.1; username='root'; password=''; database='db_pengajuan'");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string naonqueryna)
        {
            Console.WriteLine(naonqueryna);
            ds.Tables.Clear();
            perintah = new MySqlCommand(naonqueryna, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }

    }
}
