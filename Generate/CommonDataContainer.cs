using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS
{
    public class CommonDataContainer
    {
        public List<Abbiturient> Abbiturients { get; set; }
        //public Warehouse Warehouse { get; set; }
        //public List<Cashbox> Cashboxes { get; set; }
        public CommonDataContainer()
        {
            Abbiturients = new List<Abbiturient>();
            //Warehouse = new Warehouse();
            //Cashboxes = new List<Cashbox>() { new Cashbox(), new Cashbox(), new Cashbox() };
        }
    }
}
