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
        private Random _rnd = new Random();
        private int _idTracker = -1;
        
        private List<string> _phoneNumbers = new List<string>() {
        "82-93-94", "+7-923-848-49-20", "+2-828-394-83-83", "82-94-58", "83-58-28", "56-28-00"
        };
        public string GenerateLogin()
        {
            
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[_rnd.Next(consonants.Length)].ToUpper();
            Name += vowels[_rnd.Next(vowels.Length)];
            //int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            for (int b = 2; b < _rnd.Next(3, 9); b++)
            {
                if (b % 2 == 0)
                    Name += consonants[_rnd.Next(consonants.Length)];
                else
                    Name += vowels[_rnd.Next(vowels.Length)];
            }
            return Name;
        }

        //public string GeneratePassword()
        //{

        //    string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x", "a", "e", "i", "o", "u", "ae", "y" };
        //    string[] vowels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        //    string password = "";
        //    password += consonants[_rnd.Next(consonants.Length)].ToUpper();
        //    password += vowels[_rnd.Next(vowels.Length)];
        //    //int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the password.
        //    for (int b = 2; b < _rnd.Next(5, 16); b++)
        //    {
        //        if (b % 2 == 0)
        //            password += consonants[_rnd.Next(consonants.Length)];
        //        else
        //            password += vowels[_rnd.Next(vowels.Length)];
        //    }
        //    return password;
        //}
        public string GeneratePassword()
        {
            string[] vowels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string password = "";
            password += vowels[_rnd.Next(vowels.Length)];

            for (int b = 2; b < _rnd.Next(5, 16); b++)
                password += vowels[_rnd.Next(vowels.Length)];

            return password;
        }

        public string lastName()
        {
            return "Bot";
        }
        List<string> firstName ()
        {
            List<string> list = new List<string>();
            string b = "";
            using (var filG = new StreamReader("FirstName.txt", System.Text.Encoding.Unicode))
                while ((b = filG.ReadLine()) != null)
                    list.Add(b);
            return list;
        }
       
        public void GenerateProgrammOb(ComboBox cbpo, ComboBox cbfo, ComboBox cboo)
        {

            new Prog_ob().ProgObSetup(cbpo);
            cbpo.SelectedIndex = _rnd.Next(0, 3);
            var setr = new SetRegistr();
            setr.CorrectSelectedIndex(cboo, cbfo, cbpo);

            if (cbfo.SelectedIndex <= 1)
                cbfo.SelectedIndex = _rnd.Next(0, 2);
            else
                cbfo.SelectedIndex = _rnd.Next(0, 1);

            cboo.SelectedIndex = _rnd.Next(0, 1);

        }
        public GenerateAbbiturients(/*9Configuration config*/)
        {

        }
        public Abbiturient GenerateNextAbbiturints()
        {
            _idTracker++;
            List<string> _firstName = firstName();
            var po = new ComboBox();
            var fo = new ComboBox();
            var oo = new ComboBox();
            GenerateProgrammOb(po, fo, oo);
            return new Abbiturient()
            {
                ID = _idTracker,
                Login = GenerateLogin(),
                Password = GeneratePassword(),
                FirstName = _firstName[_rnd.Next(0, _firstName.Count - 1)],
                LastName = lastName(),
                TrainingProgram = (string)po.SelectedItem,
                FormOfTraining = (string)fo.SelectedItem,
                Base = (string)oo.SelectedItem,
                PhoneNumber = _phoneNumbers[_rnd.Next(0, _phoneNumbers.Count)]

            };
        }
    }
}
