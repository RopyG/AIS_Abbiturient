using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace AIS
{
    public class Simulation
    {
        GenerateAbbiturients _Ga = new GenerateAbbiturients(); 
        Random rnd = new Random();
        Configuration config = new Configuration();
        bool _isActive = false;
        //CommonDataContainer cdc = new CommonDataContainer();

        //List<Abbiturient> Abbiturients = new List<Abbiturient>();
        public Label lb = new Label();

        public ListBox action = new ListBox();
        DBConnector dbc = new DBConnector();
        CommonDataContainer _entities = new CommonDataContainer();


        public Simulation (Label l)
        {
            lb = l;
        }
        public Simulation()
        {

        }

        private void GenerateClients(int amount, int delay)
        {
            
            while (_isActive)
            {
                for (int i = 0; i < amount; i++)
                {
                    if (Rng(config.newClientRate))
                    {
                        _entities.Abbiturients.Add(_Ga.GenerateNextAbbiturints());
                        //dbc.FReach(_entities);
                    }
                    Thread.Sleep(rnd.Next(delay));
                }
                lb.Invoke(new Action(() => lb.Text = (Convert.ToInt32(lb.Text) + _entities.Abbiturients.Count).ToString()));
            }
                dbc.FReach(_entities);
                _entities.Abbiturients.Clear();
        }

        private bool Rng(double percentage)
        {
            return  rnd.NextDouble() < percentage;
        }

        public void Start()
        {
            if (!_isActive)
                _isActive = true;
            Task.Run(() => GenerateClients(config.maxNewClients, config.maxNewClientDelay));
        }

        public void Stop()
        {
            _isActive = false;
        }

        public CommonDataContainer Output( )
        {
            return _entities;
        }
    }
}
