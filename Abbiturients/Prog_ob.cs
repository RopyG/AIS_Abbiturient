using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS
{
    public class Prog_ob 
    {
        public List<string> listFo = new List<string>();
        string line;
        internal enum Fo
        {
            Очное,
            Заочное,
            Очно_Заочное
        }
        
        
        static string oz = Fo.Очно_Заочное.ToString();
        static string z = Fo.Заочное.ToString();
        static string o = Fo.Очное.ToString();
        //string d = ((Fo)1).ToString();
         public enum Os
        {
            Платное,
            Бюджетное
        }
        static string p = Os.Платное.ToString();
        static string b = Os.Бюджетное.ToString();
        public string ListOut()
        {
            string list = listFo[new Random().Next(listFo.Count - 1)];
            return list;
        }

        public class B : Prog_ob
        {
            public B()
            {
                using (var filG = new StreamReader("Бакалавриат.txt", System.Text.Encoding.Unicode))
                {
                    listFo.Clear();
                    while ((line = filG.ReadLine()) != null)
                        listFo.Add(line);
                }
            }
            public void SetupB(ComboBox cb1, ComboBox cb2, ComboBox cbDirection)
            {
                cb1.Items.Add(p);
                cb1.Items.Add(b);
                cb2.Items.Add(o);
                cb2.Items.Add(z);
                cb2.Items.Add(oz);
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }
            public void SetupB(ComboBox cbDirection)
            {
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }

            //public B()
            //{ 
            //    using (var filG = new StreamReader("Бакалавриат.txt", System.Text.Encoding.Unicode))
            //    {
            //        listFo.Clear();
            //        while ((line = filG.ReadLine()) != null)
            //            listFo.Add(b);
            //    }
            //}

        }
        public class M : Prog_ob
        {
            public M()
            {
                using (var filG = new StreamReader("Магистратура.txt", System.Text.Encoding.Unicode))
                {
                    listFo.Clear();
                    while ((line = filG.ReadLine()) != null)
                        listFo.Add(line);
                }
            }
                
            public void SetupM(ComboBox cb1, ComboBox cb2, ComboBox cbDirection)
            {
                cb1.Items.Add(p);
                cb1.Items.Add(b);
                cb2.Items.Add(o);
                cb2.Items.Add(z);
                cb2.Items.Add(oz);
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }
            public void SetupM(ComboBox cbDirection)
            {
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }

            //public M()
            //{
            //    using (var filG = new StreamReader("Магистратура.txt", System.Text.Encoding.Unicode))
            //    {
            //        listFo.Clear();
            //        while ((line = filG.ReadLine()) != null)
            //            listFo.Add(b);
            //    }
            //}
        }
        public class C : Prog_ob
        {
            public C()
            {
                using (var filG = new StreamReader("Среднее профессиональное образование.txt", System.Text.Encoding.Unicode))
                {
                    listFo.Clear();
                    while ((line = filG.ReadLine()) != null)
                        listFo.Add(line);
                }
            }
            public void SetupC(ComboBox cb1, ComboBox cb2, ComboBox cbDirection)
            {
                cb1.Items.Add(p);
                cb1.Items.Add(b);
                cb2.Items.Add(o);
                cb2.Items.Add(z);
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }
            public void SetupC(ComboBox cbDirection)
            {
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }

            //public C()
            //{
            //    using (var filG = new StreamReader("Среднее профессиональное образование.txt", System.Text.Encoding.Unicode))
            //    {
            //        listFo.Clear();
            //        while ((line = filG.ReadLine()) != null)
            //            listFo.Add(b);
            //    }
            //}

        }
        public class A : Prog_ob
        {
            public A()
            {
                using (var filG = new StreamReader("Аспирантура.txt", System.Text.Encoding.Unicode))
                {
                    listFo.Clear();
                    while ((line = filG.ReadLine()) != null)
                        listFo.Add(line);
                }
            }
            public void SetupA(ComboBox cb1, ComboBox cb2, ComboBox cbDirection)
            {
                cb1.Items.Add(p);
                cb1.Items.Add(b);
                cb2.Items.Add(o);
                cb2.Items.Add(z);
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
                
            }
            public void SetupA(ComboBox cbDirection)
            {
                
                foreach (var item in listFo)
                {
                    cbDirection.Items.Add(item);
                }
            }

            //public A()
            //{
            //    using (var filG = new StreamReader("Аспирантура.txt", System.Text.Encoding.Unicode))
            //    {
            //        listFo.Clear();
            //        while ((line = filG.ReadLine()) != null)
            //            listFo.Add(b);
            //    }
            //}
        }
        public void ProgObSetup(ComboBox cb3)
        {
            cb3.Items.Clear();
            cb3.Items.Add("Бакалавриат");
            cb3.Items.Add("Магистратура");
            cb3.Items.Add("Среднее профессиональное образование");
            cb3.Items.Add("Аспирантура");
        }
        
    }
}
