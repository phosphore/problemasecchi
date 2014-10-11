using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secchi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Capacità secchio 1: ");
            int s1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Capacità secchio 2: ");
            int s2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantità desiderata: ");
            int target = Convert.ToInt32(Console.ReadLine());
            Core problema = ImpostaProblema(s1, s2, target);
            problema.Risolvi();
            Console.WriteLine("Problema risolto in " + problema.Soluzione.Passi.Count + " passi.");
            Console.WriteLine("G,P Azione");
            Console.WriteLine("________________________________");
            foreach (var a in problema.Soluzione.Passi)
            {
                Console.WriteLine(a.LivelloSecchioGrande + "," + a.LivelloSecchioPiccolo + " " + a.Azione);
            }
            Console.WriteLine("________________________________");
            
            Console.ReadKey();
        }

        static Core ImpostaProblema(int capacitàSecchio1, int capacitàSecchio2, int qtàDesiderata)
        {
            Console.WriteLine("S1: "+capacitàSecchio1+" - S2: "+capacitàSecchio2+ " | Target: "+qtàDesiderata);
            Core problema = new Core(capacitàSecchio1, capacitàSecchio2, qtàDesiderata);
            return problema;
        }
    }
}
