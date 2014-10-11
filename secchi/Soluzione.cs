using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secchi
{
    public class Soluzione
    {
        private readonly bool _Isrisolvibile;
        public bool Isrisolvibile { get { return _Isrisolvibile; } }

        private readonly List<Passo> _Passi;
        public List<Passo> Passi { get { return _Passi; } }

        internal Soluzione(bool Isrisolvibile, List<Passo> soluzione)
        {
            _Isrisolvibile = Isrisolvibile;
            _Passi = soluzione;
        }
    }
}
