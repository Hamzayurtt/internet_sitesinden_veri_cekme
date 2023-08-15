using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri url = new Uri(" https://www.onedio.com");

            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument döküman = new HtmlAgilityPack.HtmlDocument();
            döküman.LoadHtml(html);
            HtmlNodeCollection başlıklar = döküman.DocumentNode.SelectNodes("//a");
            foreach (var başlık in başlıklar)
            {
                string link =başlık.Attributes["href"].Value;
                listBox1.Items.Add  ( başlık.InnerText);
            }

        }
    }
}
