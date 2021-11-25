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
    public partial class ListForm : Form
    {
        
        public ListForm(CommonDataContainer b)
        {
            InitializeComponent();
            foreach (var line in b.Abbiturients)
            {
                listBox1.Items.Add($"{line.ID} {line.FirstName} {line.LastName} {line.TrainingProgram} {line.FormOfTraining} {line.Base} {line.Direction} {line.PhoneNumber}");
            }
        }
        private void ListForm_Load(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
