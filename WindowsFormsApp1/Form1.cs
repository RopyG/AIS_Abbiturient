using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Dictionary<string, float[]> currenciesDictionary = new Dictionary<string, float[]>();
        public Form1()
        {
            InitializeComponent();
            label1.Paint += Label1_Paint;
            label2.Paint += Label2_Paint;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            
            Download("https://www.moex.com/export/derivatives/currency-rate.aspx?language=en&currency=USD/RUB&moment_start=2021-09-06&moment_end=2021-10-06", "usd_rub.xml");
            Download("https://www.moex.com/export/derivatives/currency-rate.aspx?language=en&currency=EUR/RUB&moment_start=2021-09-14&moment_end=2021-10-14", "eur_rub.xml");
            Download("https://www.moex.com/export/derivatives/currency-rate.aspx?language=en&currency=TRY/RUB&moment_start=2021-09-14&moment_end=2021-10-14", "try_rub.xml");
            ParseCurrencies("usd");
            ParseCurrencies("eur");
            ParseCurrencies("try");
        }

        public void Download(string URL, string filename)
        {
            using (var clientA = new WebClient())
            {
                clientA.DownloadFile(URL, filename);
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            Drawing("usd");
        }
        void button2_Click(object sender, EventArgs e)
        {
            Drawing("eur");
        }
        void button3_Click(object sender, EventArgs e)
        {
            Drawing("try");
            
        }

        public void Label1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(label1.Text, label1.Font);
            label1.Width = (int)textSize.Height + 2;
            label1.Height = (int)textSize.Width + 2;
            e.Graphics.TranslateTransform(-label1.Height / 2, label1.Width / 2);
            e.Graphics.DrawString(label1.Text, label1.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }
        public void Label2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.RotateTransform(-90);
            SizeF textSize = e.Graphics.MeasureString(label2.Text, label2.Font);
            label2.Width = (int)textSize.Height + 2;
            label2.Height = (int)textSize.Width + 7;
            e.Graphics.TranslateTransform(-label2.Height /2, label2.Width /2);
            e.Graphics.DrawString(label2.Text, label2.Font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
        }


        void ParseCurrencies(string con)
        {
            using (var myFileStrem = new FileStream($"{con}_rub.xml", FileMode.Open))
            {
                var rtsdata = new Rtsdata();
                var mySerializer = new XmlSerializer(typeof(Rtsdata));
                var myObject = (Rtsdata)mySerializer.Deserialize(myFileStrem);
                int p = myObject.MyList.Count;
                float[] array = new float[p];
                foreach (var Rate in myObject.MyList)
                {
                    for (int i = 0; i < p; i++)
                    {
                        array[i] = myObject.MyList[i].Value;
                    }
                }
                currenciesDictionary.Add(con, array);
            }
        }

        
        void Drawing(string con)
        {
            float[] s = currenciesDictionary[con];
            int p = s.Length;
            Graphics g = pictureBox1.CreateGraphics();
            int xDiff = pictureBox1.Width / (p-1);
            float[] points = new float[p];
            for (int i = 0; i < p; i++)
                points[i] = (s[i] * 100);
            int max = (int)points.Max();
            int min = (int)points.Min();
            int yDiff = pictureBox1.Height / (max - min);
            int x = 0;
            Array.Reverse(points);
            PointF[] ptf = new PointF[p];

            g.Clear(pictureBox1.BackColor);

            label3.Text = (max/100).ToString();
            label4.Text = (min/100).ToString();


            PointF[] screenPoints = new PointF[p];
            for(int i = 0; i < p; i++)
            {
                screenPoints[i] = new PointF(x, (int)(points[i] - min) * yDiff);
                x += xDiff;
            }
          
            Pen myPen = new Pen(Color.Black);
            g.DrawLines(myPen, screenPoints);
            g.Dispose();
        }

        
        [Serializable()]
        [XmlRoot("rtsdata")]
        public class Rtsdata
        {
            [XmlArray("rates")]
            [XmlArrayItem("rate")]
            public List<Rate> MyList { get; set; }
        }
        [Serializable()]
        public class Rate
        {
            [XmlAttribute("moment")]
            public string Moment { get; set; }
            [XmlAttribute("value")]
            public float Value { get; set; }
        }

    }
}
