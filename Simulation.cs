using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using 

namespace AIS
{
    public class Simulation
    {
        CommonDataContainer _entitity = new CommonDataContainer();
        GenerateAbbiturients _Ga = new GenerateAbbiturients(); 
        private Random rnd = new Random();
        //Random rnd = new Random();
        Configuration config = new Configuration();
        bool _isActive = false;
        Abbiturient abb = new Abbiturient();
        GenerateAbbiturients gen = new GenerateAbbiturients();
        CommonDataContainer _entities = new CommonDataContainer();
        public ListBox box = new ListBox();

        private void GenerateClients(int amount, int delay)
        {
            while (_isActive)
            {
                for (int i = 0; i < amount; i++)
                {
                    if (Rng(config.newClientRate))
                    {
                        _entities.Abbiturients.Add(_Ga.GenerateNextAbbiturints());
                    }
                        
                    Thread.Sleep(rnd.Next(delay));
                }
                
            }
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
            //Task.Run(() =>);

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
