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


// adres kısmında yazan web sitesinin başılığını görüntüleme
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string adres = "http://www.tesla.com";
            WebRequest request = HttpWebRequest.Create(adres);
            WebResponse response;
            response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string gelen = streamReader.ReadToEnd();
            int başlıkbaşlangıç=gelen.IndexOf("<title>")+7;
            int başlıkbitiş = gelen.Substring(başlıkbaşlangıç).IndexOf("</title>");
            string başlık = gelen.Substring(başlıkbaşlangıç, başlıkbitiş);
            
            MessageBox.Show( başlık ,"MessageBox Başlığı ",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            label1.Text = $"{başlık}";
            

        }
    }
}
