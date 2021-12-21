using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIS.ProjectForms;
//using AIS.Form;

namespace AIS
{
    public partial class HomeForm : System.Windows.Forms.Form
    {
        Dictionary<string, System.Windows.Forms.Form> _form = new Dictionary<string, System.Windows.Forms.Form>();
        private DBConnector _dbc;
        private System.Windows.Forms.Form _currentChildForm;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            _dbc = new DBConnector();
            _dbc.Connect(this);

            _form.Add("Registration", new RegistrationForm());
            _form.Add("Simulation", new SimulationForm());
            _form.Add("DataBase", new DBForm());
        }

        private void OpenChildForm(System.Windows.Forms.Form childForm)
        {
            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHome.Controls.Remove(_currentChildForm);
            panelHome.Controls.Add(childForm);
            panelHome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            OpenChildForm(_form["Registration"]);
        }

        private void buttonSim_Click(object sender, EventArgs e)
        {
            OpenChildForm(_form["Simulation"]);
        }

        private void buttonDB_Click(object sender, EventArgs e)
        {
            OpenChildForm(_form["DataBase"]);
        }
    }
}
