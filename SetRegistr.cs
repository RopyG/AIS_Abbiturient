using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS;
using System.Windows.Forms;
using System.IO;

namespace AIS
{
    public class SetRegistr
    {

        public void SetYears(ComboBox cb)
        {
            var dt = DateTime.Today.Year;
            for (int i = 0; i <= 120; i++)
                cb.Items.Add(dt - i);
        }

        public DateTime CorrectData(ComboBox cb, ComboBox mm, ComboBox dd)
        {
            DateTime trutime = new DateTime();
            try
            {
                int year = Convert.ToInt32(cb.SelectedItem);
                int mounth = Convert.ToInt32(mm.SelectedItem);
                int day = Convert.ToInt32(dd.SelectedItem);
                trutime = new DateTime(year, mounth, day);
                return trutime;
            }
            catch
            {
                return trutime;
            }
        }

        public void CorrectSelectedIndex(ComboBox cb1, ComboBox cb2, ComboBox cb3, ComboBox cbDirection)
        {
            if (cb3.SelectedIndex == 0)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cbDirection.Items.Clear();
                cb1.Enabled = true;
                cb2.Enabled = true;
                cbDirection.Enabled = true;
                new Prog_ob.B().SetupB(cb1, cb2, cbDirection);

            }

            if (cb3.SelectedIndex == 1)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cbDirection.Items.Clear();
                cb1.Enabled = true;
                cb2.Enabled = true;
                cbDirection.Enabled = true;
                new Prog_ob.M().SetupM(cb1, cb2, cbDirection);
            }

            if (cb3.SelectedIndex == 2)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cbDirection.Items.Clear();
                cb1.Enabled = true;
                cb2.Enabled = true;
                cbDirection.Enabled = true;
                new Prog_ob.C().SetupC(cb1, cb2, cbDirection);
            }

            if (cb3.SelectedIndex == 3)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cbDirection.Items.Clear();
                cb1.Enabled = true;
                cb2.Enabled = true;
                cbDirection.Enabled = true;
                new Prog_ob.A().SetupA(cb1, cb2, cbDirection);
            }

        }

        public void CorrectindexFor_SortForm(ComboBox progOb, ComboBox direction, CheckBox allProgOb, CheckBox allDirection)
        {
            switch (progOb.SelectedIndex)
            {
                case 0:
                    direction.Items.Clear();
                    direction.Enabled = true;
                    allDirection.Enabled = true;
                    allDirection.Checked = false;
                    new Prog_ob.B().SetupB(direction);
                    break;
                case 1:
                    direction.Items.Clear();
                    direction.Enabled = true;
                    allDirection.Enabled = true;
                    allDirection.Checked = false;
                    new Prog_ob.M().SetupM(direction);
                    break;
                case 2:
                    direction.Items.Clear();
                    direction.Enabled = true;
                    allDirection.Enabled = true;
                    allDirection.Checked = false;
                    new Prog_ob.C().SetupC(direction);
                    break;
                case 3:
                    direction.Items.Clear();
                    direction.Enabled = true;
                    allDirection.Enabled = true;
                    allDirection.Checked = false;
                    new Prog_ob.A().SetupA(direction);
                    break;
                default:
                    break;
            }

        }

        public void CorrectProgObheckedFor_SortForm(ComboBox progOb, ComboBox direction, CheckBox allProgOb, CheckBox allDirection, CheckBox enrollment)
        {
            switch (allProgOb.Checked)
            {
                case true:
                    progOb.Text = null;
                    direction.Text = null;
                    progOb.Enabled = false;
                    direction.Enabled = false;
                    allDirection.Enabled = false;
                    enrollment.Checked = false;
                    enrollment.Enabled = false;
                    break;
                case false:
                    progOb.Enabled = true;
                    enrollment.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        public void CorrectDirectionCheckedFor_SortForm(ComboBox direction, CheckBox allDirection, CheckBox enrollment)
        { 
            switch (allDirection.Checked)
            {
                case true:
                    direction.Text = null;
                    direction.Enabled = false;
                    enrollment.Checked = false;
                    enrollment.Enabled = false;
                    break;
                case false:
                    direction.Enabled = true;
                    enrollment.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        public void CorrectEnrollment(CheckBox enrollment, TextBox abiturValue, Label abiturients)
        {
            switch (enrollment.Checked)
            {
                case true:
                    abiturValue.Enabled = true;
                    abiturients.Enabled = true;
                    abiturValue.Text = Convert.ToString(30);
                    break;
                case false:
                    abiturValue.Enabled = false;
                    abiturients.Enabled = false;
                    abiturValue.Clear();
                    break;
                default:
                    break;
            }
        }

    }
}
