using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secchi
{
    public class Passo
    {
        private readonly int _livelloSecchioPiccolo;
        public int LivelloSecchioPiccolo { get { return _livelloSecchioPiccolo; } }

        private readonly int _livelloSecchioGrande;
        public int LivelloSecchioGrande { get { return _livelloSecchioGrande; } }

        private readonly Azione _azione;
        public Azione Azione { get { return _azione; } }

        internal Passo(int livelloSecchioPiccolo, int livelloSecchioGrande, Azione azione)
        {
            _livelloSecchioPiccolo = livelloSecchioPiccolo;
            _livelloSecchioGrande = livelloSecchioGrande;
            _azione = azione;
        }
    }

    public enum Azione
    {
        SVUOTA,
        RIEMPI,
        TRAVASA
    }
}
