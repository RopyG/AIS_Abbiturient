using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Курсовая;
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
                int mounth = Convert.ToInt32( mm.SelectedItem);
                int day = Convert.ToInt32(dd.SelectedItem);
                trutime = new DateTime(year, mounth, day);
                return trutime;
            }
            catch
            {
                return trutime;
            }
        }

        public void ParseToFile(DateTime date, TextBox fio, ComboBox po, ComboBox fo, ComboBox oo)
        {
            
            string path = $@"F:\corse\Abbiturients\Abbitr.txt";
            if (date == new DateTime())
            {
                MessageBox.Show("Неверная дата", "Ожибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using(var ds = new StreamWriter(path, true))
            {

                ds.WriteLine($@"ФИО: {fio.Text}, Программа обучения: {po.SelectedItem}, Форма обучения: {fo.SelectedItem}, Основа обучения: {oo.SelectedItem}, Направление: ");
            }
        }

        public void CorrectSelectedIndex(ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            if (cb3.SelectedIndex == 0)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cb2.Enabled = true;
                cb1.Enabled = true;
                new Prog_ob.B().SetupB(cb1, cb2);
                
            }
            
            if (cb3.SelectedIndex == 1)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cb2.Enabled = true;
                cb1.Enabled = true;
                new Prog_ob.M().SetupM(cb1, cb2);
            }
            
            if (cb3.SelectedIndex == 2)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cb2.Enabled = true;
                cb1.Enabled = true;
                new Prog_ob.C().SetupC(cb1, cb2);
            }
            
            if (cb3.SelectedIndex == 3)
            {
                cb1.Items.Clear();
                cb2.Items.Clear();
                cb2.Enabled = true;
                cb1.Enabled = true;
                new Prog_ob.A().SetupA(cb1, cb2);
            }
            
        }

    }
}
