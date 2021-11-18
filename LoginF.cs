using AIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        GenerateAbbiturients simGen = new GenerateAbbiturients();
        Prog_ob.B po = new Prog_ob.B();
        Simulation sim = new Simulation();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //label4.Text = sim.RandomFirstName();
            
            
            label4.Text = po.ListOut();
        }
    }
}
