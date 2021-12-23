using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS.ProjectForms
{
    public partial class SelectSortForm : Form
    {
        DBConnector _dbc = new DBConnector();
        SetRegistr _set = new SetRegistr();

        public SelectSortForm()
        {
            InitializeComponent();
            abiturValueBox.MaxLength = 2;
            _dbc.Connect(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (enrollmentChBox.Checked = true && progObCBo.SelectedItem != null && directionCBox.SelectedItem != null)
            {
                _dbc.SelectAbbiturientEnrollment(progObCBo, directionCBox, abiturValueBox);
                MessageBox.Show("Докуммент создан в C:/Doc/", "Записано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (allProgObChBox.Checked == true)
            {
                 _dbc.SelectAbbiturientAll();
                MessageBox.Show("Докуммент создан в C:/Doc/", "Записано", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (progObCBo.SelectedItem != null && allDirectionChBox.Checked == true)
            {
                 _dbc.SelectAbbiturientCertainProg_Ob(progObCBo);
                MessageBox.Show("Докуммент создан в C:/Doc/", "Записано", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (progObCBo.SelectedItem != null && directionCBox.SelectedItem != null)
            {
                _dbc.SelectAbbiturientCertainProg_ObAndCertainDirection(progObCBo, directionCBox);
                MessageBox.Show("Докуммент создан в C:/Doc/", "Записано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                else
                    MessageBox.Show("Ошибка!", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }

        private void SelectSortForm_Load(object sender, EventArgs e)
        {

        }

        private void progObCBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _set.CorrectindexFor_SortForm(progObCBo, directionCBox, allProgObChBox, allDirectionChBox);
        }

        private void directionCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void allProgObChBox_CheckedChanged(object sender, EventArgs e)
        {
            _set.CorrectProgObheckedFor_SortForm(progObCBo, directionCBox, allProgObChBox, allDirectionChBox, enrollmentChBox);
        }

        private void allDirectionChBox_CheckedChanged(object sender, EventArgs e)
        {
            _set.CorrectDirectionCheckedFor_SortForm(directionCBox, allDirectionChBox, enrollmentChBox);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _set.CorrectEnrollment(enrollmentChBox, abiturValueBox, abiturientsLabel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adirueValueBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void adirueValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }
    }
}
