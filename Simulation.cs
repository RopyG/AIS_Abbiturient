using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AIS
{
    public class Simulation
    {
        List<string> _entities;
        private Random rnd = new Random();
        //Random rnd = new Random();
        Configuration config = new Configuration();
        bool _isActive = false;
        GenerateAbbiturients gen = new GenerateAbbiturients();


        private void GenerateClients(int amount, int delay)
        {
            while (_isActive)
            {
                for (int i = 0; i < amount; i++)
                {
                    if (Rng(config.newClientRate))
                        _entities.Clients.Add(_cG.GenerateNextClient());
                    Thread.Sleep(_rng.Next(delay));
                }
            }
        }
        private bool Rng(double percentage)
        {
            return  .NextDouble() < percentage;
        }

        public void Start()
        {
            if (!_isActive)
                _isActive = true;
            //Task.Run(() =>);
        }

    }
}
