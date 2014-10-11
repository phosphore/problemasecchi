using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secchi
{
    public class Secchio
    {
        private readonly int _capacità;
        public int Capacità { get { return _capacità; } }

        public int Livello { get; private set; }
        public int Rimanente { get { return Capacità - Livello; } }

        public bool IsVuoto { get { return Livello == 0; } }
        public bool IsPieno { get { return Rimanente == 0; } }

        public Secchio(int capacità)
        {
            _capacità = capacità;
        }

        public void Riempi()
        {
            Livello = Capacità;
        }

        public void Svuota()
        {
            Livello = 0;
        }

        public void TrasferisciA(Secchio secchio)
        {
            int trasf = 0;

            if(this.Livello <= secchio.Rimanente)
            {
                trasf = this.Livello; 
            }

            else if(this.Livello > secchio.Rimanente)
            {
                trasf = secchio.Rimanente;
            }

            secchio.Livello += trasf;
            this.Livello -= trasf;
        }
    }
}