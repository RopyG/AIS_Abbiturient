using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIS;


namespace AIS.ProjectForms
{
    public partial class RegistrationForm : System.Windows.Forms.Form
    {
        DBConnector dbc = new DBConnector();

        SetRegistr setR = new SetRegistr();
        private Button backButton;
        private Button addButton;
        private TextBox textBox1;
        private Label nameLabel;
        private Label ProgObLabel;
        private Label formTrainingLabel;
        private Label trainingOfFormLabel;
        private Label phoneNumberLabel;
        private TextBox textBox5;
        private Label directionLabel;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        Split split = new Split();
        public RegistrationForm()
        {
            InitializeComponent();
            dbc.Connect(this);
            new Prog_ob().ProgObSetup(traningProgCBox);
            textBox2.MaxLength = 3;
            //TimeoutAsync(comboBox1, comboBox2, comboBox3);//setR.Correct(comboBox1, comboBox2, comboBox3);
            setR.SetYears(yearCBox);
            loginTextBox.MaxLength = 20;
            passwordTextBox.MaxLength = 20;

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
            //setR.CorrectData(yearCBox, mounthCBox, dayCBox);
            //setR.ParseToFile(dt, textBox1, comboBox3, comboBox2, comboBox1);
            //label9.Text = comboBox3.SelectedIndex.ToString();
            try
            {
                dbc.InsertAbbiturient(split.RegexSplit(nameCBox.Text)[0], split.RegexSplit(nameCBox.Text)[1], traningProgCBox.Text, formTrainingCBox.Text, baseCBox.Text, directionCBox.Text, phoneBox.Text, textBox2.Text);
                MessageBox.Show("Aббитуриент добавлен", "Aббитуриент добавлен", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch //(Exception)
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
            //dbc.InsertAbbiturient("awddasd","saaawd","awdawd","awddwa","wadawd","sadawd","yread");


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            setR.CorrectSelectedIndex(baseCBox, formTrainingCBox, traningProgCBox, directionCBox);
        }

        private void form2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            nameCBox.Text = nameCBox.Text.TrimStart();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbc.CreateAccount(loginTextBox.Text, passwordTextBox.Text);
        }
    }
}
