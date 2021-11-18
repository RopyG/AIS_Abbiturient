using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS
{
    public class GenerateAbbiturients
    {
        //Configuration config;
        private Random rnd = new Random();
        public string GenerateNickName(int len/*от 3 до 8*/)
        {
            
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[rnd.Next(consonants.Length)].ToUpper();
            Name += vowels[rnd.Next(vowels.Length)];
            //int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            for (int b = 2; b < len; b++)
            {
                if (b % 2 == 0)
                    Name += consonants[rnd.Next(consonants.Length)];
                else
                    Name += vowels[rnd.Next(vowels.Length)];
            }
            return Name;
        }
        public string SecondName(int rand/*от 0 до 1*/)
        {
            if (rand == 0)
                return "Ботов";
            else if (rand == 1)
                return "Ботовна";
            else
                return "Бот";
        }
        void SetupFirstName(List<string> list)
        {
            string b = "";
            if (rnd.Next(0, 1) == 0)
                using (var filG = new StreamReader($@"F:\corse\Abbiturients\Abbitr.txt", System.Text.Encoding.Unicode))
                    while ((b = filG.ReadLine()) != null)
                        list.Add(b);
            else
                using (var filM = new StreamReader($@"F:\corse\Abbiturients\Abbitr.txt", System.Text.Encoding.Unicode))
                    while ((b = filM.ReadLine()) != null)
                        list.Add(b);
        }
        public string RandomFirstName()
        {
            List<string> list = new List<string>();
            this.SetupFirstName(list);
            string name = list[rnd.Next(0, 202)];
            return name;
        }
        //ComboBox ProgOb()
        //{
        //    ComboBox comBox = new ComboBox();
        //    comBox.Items.Add("Бакалавриат");
        //    comBox.Items.Add("Магистратура");
        //    comBox.Items.Add("Среднее профессиональное образование");
        //    comBox.Items.Add("Аспирантура");
        //    return comBox;
        //}
        public string GenerateProgrammOb()
        {
            ComboBox cbfo = new ComboBox();
            ComboBox cbpo = new ComboBox();
            ComboBox cboo = new ComboBox();

            new Prog_ob().ProgObSetup(cbfo);
            cbfo.SelectedIndex = rnd.Next(0, 3);
            var setr = new SetRegistr();
            setr.CorrectSelectedIndex(cboo, cbpo, cbfo);

            if (cbfo.SelectedIndex <= 1)
                cbpo.SelectedIndex = rnd.Next(0, 2);
            else
                cbpo.SelectedIndex = rnd.Next(0, 1);

            cboo.SelectedIndex = rnd.Next(0, 1);

            string bac = $@"{cbfo.SelectedItem} {cbpo.SelectedItem} {cboo.SelectedItem}";

            return bac;
        }
        public GenerateAbbiturients(/*9Configuration config*/)
        {

        }
    }
}
