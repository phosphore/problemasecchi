using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secchi
{
    public class Core
    {
            public int CapacitàSecchio1 { get; set; }
            public int CapacitàSecchio2 { get; set; }
            public int QtàDesiderata { get; set; }

            public Soluzione Soluzione { get; private set; }

            public Core(int capacitàSecchio1, int capacitàSecchio2, int qtàDesiderata)
            {
                CapacitàSecchio1 = capacitàSecchio1;
                CapacitàSecchio2 = capacitàSecchio2;
                QtàDesiderata = qtàDesiderata;
            }

            public Soluzione Risolvi()
            {

                Soluzione soluzione1 = null;
                Soluzione soluzione2 = null;

                //Eseguo entrambi i metodi contemporaneamente per successivamente determinare quello effettivamente risolvibile e con il minor numero di passi
                Parallel.Invoke(
                    () => { soluzione1 = Risolvicr(CapacitàSecchio1, CapacitàSecchio2, QtàDesiderata); },
                    () => { soluzione2 = Risolvidec(CapacitàSecchio1, CapacitàSecchio2, QtàDesiderata); }
                    );


                if (soluzione1.Isrisolvibile && soluzione1.Passi.Count <= soluzione2.Passi.Count)
                {
                    Soluzione = soluzione1;
                    Console.WriteLine(" SOLUZIONE 1 SCELTA ");
                }
                else if (soluzione1.Isrisolvibile && !soluzione2.Isrisolvibile)
                {
                    Soluzione = soluzione1;
                    Console.WriteLine(" SOLUZIONE 1 SCELTA ");
                }
                else if (soluzione2.Isrisolvibile && soluzione2.Passi.Count <= soluzione1.Passi.Count)
                {
                    Soluzione = soluzione2;
                    Console.WriteLine(" SOLUZIONE 2 SCELTA ");
                }
                else if (soluzione2.Isrisolvibile && !soluzione1.Isrisolvibile)
                {
                    Soluzione = soluzione2;
                    Console.WriteLine(" SOLUZIONE 2 SCELTA ");
                }
                else
                {
                    Soluzione = null;
                }

                //Espressione ternaria dell'if chain precedente
      //          Soluzione =
      //              soluzione1.Isrisolvibile && soluzione1.Passi.Count <= soluzione2.Passi.Count ? soluzione1 :
      //              soluzione1.Isrisolvibile && !soluzione2.Isrisolvibile ? soluzione1 :
      //              soluzione2.Isrisolvibile && soluzione2.Passi.Count <= soluzione1.Passi.Count ? soluzione2 :
      //              soluzione2.Isrisolvibile && !soluzione1.Isrisolvibile ? soluzione2 :
      //              null;


                return Soluzione;
            }

            private Soluzione Risolvicr(int capacitàSecchio1, int capacitàSecchio2, int livelloDesiderato)
            {
                if (capacitàSecchio1 == capacitàSecchio2)
                {
                    throw new Exception("Impossibile"); //impossibile risolvere
                }

                int capacitàSecchioPiccolo = capacitàSecchio1 < capacitàSecchio2 ? capacitàSecchio1 : capacitàSecchio2;
                int capacitàSecchioGrande = capacitàSecchio1 > capacitàSecchio2 ? capacitàSecchio1 : capacitàSecchio2;

                Secchio secchioPiccolo = new Secchio(capacitàSecchioPiccolo);
                Secchio secchioGrande = new Secchio(capacitàSecchioGrande);
                List<Passo> passi = new List<Passo>();

                while ((secchioPiccolo.Livello != livelloDesiderato) && (secchioGrande.Livello != livelloDesiderato) && (secchioPiccolo.Livello + secchioGrande.Livello != livelloDesiderato))
                {
                    Passo passo;

                    if (secchioGrande.IsVuoto)
                    {
                        secchioGrande.Riempi();
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.RIEMPI);
                    }
                    else if (!secchioPiccolo.IsPieno)
                    {
                        secchioGrande.TrasferisciA(secchioPiccolo);
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.TRAVASA);
                    }
                    else
                    {
                        secchioPiccolo.Svuota();
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.SVUOTA);
                    }

                    //Abbiamo raggiunto la soluzione?
                    if (passi.Exists(x => x.LivelloSecchioPiccolo == passo.LivelloSecchioPiccolo && x.LivelloSecchioGrande == passo.LivelloSecchioGrande))
                    {
                        return new Soluzione(false, passi);
                    }

                    passi.Add(passo);
                }

                return new Soluzione(true, passi);
            }

            private Soluzione Risolvidec(int capacitàSecchio1, int capacitàSecchio2, int livelloDesiderato)
            {
                if (capacitàSecchio1 == capacitàSecchio2)
                {
                    throw new Exception("Impossibile"); //impossibile risolvere
                }

                int capacitàSecchioPiccolo = capacitàSecchio1 < capacitàSecchio2 ? capacitàSecchio1 : capacitàSecchio2;
                int capacitàSecchioGrande = capacitàSecchio1 > capacitàSecchio2 ? capacitàSecchio1 : capacitàSecchio2;

                Secchio secchioPiccolo = new Secchio(capacitàSecchioPiccolo);
                Secchio secchioGrande = new Secchio(capacitàSecchioGrande);
                List<Passo> passi = new List<Passo>();

                while ((secchioPiccolo.Livello != livelloDesiderato) && (secchioGrande.Livello != livelloDesiderato) && (secchioPiccolo.Livello + secchioGrande.Livello != livelloDesiderato))
                {
                    Passo passo;

                    if (secchioPiccolo.IsVuoto)
                    {
                        secchioPiccolo.Riempi();
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.RIEMPI);
                    }
                    else if (!secchioGrande.IsPieno)
                    {
                        secchioPiccolo.TrasferisciA(secchioGrande);
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.TRAVASA);
                    }
                    else
                    {
                        secchioGrande.Svuota();
                        passo = new Passo(secchioPiccolo.Livello, secchioGrande.Livello, Azione.SVUOTA);
                    }
                    //Abbiamo raggiunto la soluzione?
                    if (passi.Exists(x => x.LivelloSecchioPiccolo == passo.LivelloSecchioPiccolo && x.LivelloSecchioGrande == passo.LivelloSecchioGrande))
                    {
                        return new Soluzione(false, passi);
                    }

                    passi.Add(passo);
                }
                
                return new Soluzione(true, passi);
            
        }

    }
}
