using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace SAYAC
{
    class SqlC
    {
        public static SqlConnection con = new SqlConnection(@"server = " + SqlC.dosyadanOku()[0].ToString() + "; Database = " + dbname + ";User ID = sa; Password=" + SqlC.dosyadanOku()[0].ToString());
        public static string dbname = "master";
        public static SqlCommand com = new SqlCommand();
        public static SqlDataAdapter daa = new SqlDataAdapter(com);



        public static string[] dosyadanOku()
        {
            string dosya_yolu = @"C:\yeniklasor\settings.txt";

            string[] Settings = System.IO.File.ReadAllLines(dosya_yolu, Encoding.GetEncoding("windows-1254"));


            return Settings;


        }

        public static bool dbkont()
        {
            bool kontrol = false;
            DataSet dataset = new DataSet();
            con.Open();
            com.CommandText = "SELECT name FROM master.dbo.sysdatabases";
            com.Connection = SqlC.con;
            daa.SelectCommand = com;

            daa.Fill(dataset);
            //MessageBox.Show(dataset.Tables[0].Rows[1].ItemArray[0].ToString());
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {

                if (dataset.Tables[0].Rows[i].ItemArray[0].ToString() == "KASA")
                {
                    MessageBox.Show("DB ZATEN OLUŞTURULMUŞ");
                    kontrol = true;

                }
            }

            con.Close();

            return kontrol;


        }
        public static void dbolustur()
        {
            if (SqlC.dbkont() == false)
            {
                try
                {
                    SqlC.con.Open();
                    SqlC.com.CommandText = "CREATE DATABASE KASA;";
                    SqlC.com.Connection = SqlC.con;
                    SqlC.com.ExecuteNonQuery();
                    SqlC.con.Close();
                    SqlC.con.Open();
                    SqlC.com.CommandText = "use kasa CREATE TABLE CARI( FISno INT IDENTITY(1, 1),tarih date, kullanıcı nchar(255) , gelir bit, değer int,Acıklama varchar(255), CONSTRAINT FISno PRIMARY KEY(FISno) ); ";
                    SqlC.com.Connection = SqlC.con;
                    SqlC.com.ExecuteNonQuery();
                    SqlC.con.Close();
                    MessageBox.Show("DB BAŞIRI İLE OLUŞTURULDU");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("hata    !" + ex);

                }

            }

        }



    }
}
