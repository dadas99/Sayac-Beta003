using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SAYAC
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// use FSayac CREATE TABLE CARI( CariNo INT IDENTITY(1, 1),CARI_AD varchar(255), Adres Varchar(255) ,Acıklama varchar(255), CONSTRAINT FISno PRIMARY KEY(FISno) );
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 ff = new Form4();
            ff.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\yeniklasor\settings.txt") == false)
            {
                Directory.CreateDirectory(@"C:\yeniklasor");
                FileStream fs = new FileStream(@"C:\yeniklasor\settings.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("127.0.0.1");
                sw.WriteLine("likompresto%1");
                sw.WriteLine("0");

                sw.Close();
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
