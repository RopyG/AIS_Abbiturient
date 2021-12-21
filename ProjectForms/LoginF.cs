using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AIS.ProjectForms;

namespace AIS
{
    public partial class LoginF : System.Windows.Forms.Form
    {
        DBConnector dbc = new DBConnector();
        public LoginF()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dbc.Connect(this);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm fr = new RegistrationForm();
            fr.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //new ListForm(sim.Output()).ShowDialog();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            //dbc.InsertAbbiturient(label3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm dbf = new HomeForm();
            dbf.ShowDialog();
        }
    }
}
