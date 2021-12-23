﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS
{
    public partial class SimulationForm : System.Windows.Forms.Form
    {
        Simulation sim;
        DBConnector dbc = new DBConnector();
        public SimulationForm()
        {
            InitializeComponent();

        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            sim = new Simulation(label2);
            //dbc.Connect();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sim.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sim.Stop();
        }
    }
}
