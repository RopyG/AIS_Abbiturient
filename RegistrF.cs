using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсовая;


namespace AIS
{
    public partial class Form2 : Form
    {

        SetRegistr setR = new SetRegistr();
        public Form2()
        {
            InitializeComponent();
            new Prog_ob().ProgObSetup(comboBox3);
            
            //TimeoutAsync(comboBox1, comboBox2, comboBox3);//setR.Correct(comboBox1, comboBox2, comboBox3);
            setR.SetYears(comboBox6);


        }

        public void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = setR.CorrectData(comboBox6, comboBox5, comboBox4);
            setR.ParseToFile(dt, textBox1, comboBox3, comboBox2, comboBox1);
            //label9.Text = comboBox3.SelectedIndex.ToString();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            setR.CorrectSelectedIndex(comboBox1, comboBox2, comboBox3);
        }

        private void form2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
