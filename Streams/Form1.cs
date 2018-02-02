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
using System.Net;
using System.IO.Compression;

namespace Streams
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Vyber subor";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter ="Text files(TXT) |*.TXT";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                textBox1.Text = openFileDialog1.FileName;

                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string obsahSuboru = reader.ReadToEnd();
                    textBox2.Text = obsahSuboru;
                }

                using (StreamWriter writer = new StreamWriter(@"c:\temp\kopia.txt",true))
                {
                    writer.Write(textBox2.Text.ToUpper());
                }
                ZipFile.CreateFromDirectory(@"C:\temp", @"C:\temp1\kopia.zip");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            WebClient webClient = new WebClient();
            using (StreamReader htmlReader = new StreamReader(webClient.OpenRead(textBox3.Text)))
            {
                textBox2.Text = htmlReader.ReadToEnd();
            }
        }
    }
}
