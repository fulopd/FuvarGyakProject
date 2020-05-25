using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuvarGyakProject
{
    class FuvarokRepository
    {
        List<Fuvar> fuvarokLista;

        public FuvarokRepository()
        {
            fuvarokLista = new List<Fuvar>();
            Beolvas();
        }

        private void Beolvas()
        {
            using (var sr = new StreamReader("forras/fuvar.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    fuvarokLista.Add(new Fuvar(
                                            Convert.ToInt32(sor[0]),
                                            Convert.ToDateTime(sor[1]),
                                            Convert.ToDouble(sor[2]),
                                            Convert.ToDouble(sor[3]),
                                            Convert.ToDouble(sor[4]),
                                            Convert.ToDouble(sor[5]),
                                            sor[6]
                                            ));
                }
            }
        }

        public int Count()
        {
            return fuvarokLista.Count();
        }

        public void BevetelAzonositoAlapjan()
        {
            var bevetel = fuvarokLista.Where(x => x.taxi_id.Equals(6185)).ToList();

            double bevetelAlap = 0;
            foreach (var item in bevetel)
            {
                bevetelAlap += item.viteldij;
            }

            Console.WriteLine(bevetel.Count() + " fuvar alatt: " + bevetelAlap + "$");
        }

        public void FizetesiModokStatisztika()
        {
            var fizmod = fuvarokLista.GroupBy(x => x.fizetes_modja).ToList();
            fizmod.ForEach(x => Console.WriteLine("\t" + x.Key + ": " + x.Count() + " fuvar"));
        }

        public double OsszMegtettKilometer()
        {
            return Math.Round(fuvarokLista.Sum(x => x.tavolsag) * 1.6, 2);
        }

        public void LeghosszabbFuvar()
        {
            double max = 0;
            Fuvar leghFuvar = null;

            foreach (var item in fuvarokLista)
            {
                if (max < item.idotartam)
                {
                    max = item.idotartam;
                    leghFuvar = item;
                }
            }
            Console.WriteLine("\tFuvar hossza: " + leghFuvar.idotartam + " másodperc");
            Console.WriteLine("\tTaxis azonosító: " + leghFuvar.taxi_id);
            Console.WriteLine("\tMegtett távolság: " + leghFuvar.tavolsag + "Km");
            Console.WriteLine("\tViteldíj: " + leghFuvar.viteldij + "$");


            //vagy egyszerübben :)
            Console.WriteLine("Másik módszerrel:");

            var legH = fuvarokLista.OrderByDescending(x => x.idotartam).ToList();
            Console.WriteLine("\tFuvar hossza {0} másodperc\n" +
                              "\tTaxis azonosító: {1}\n" +
                              "\tMegtett távolság: {2} km\n" +
                              "\tViteldíj: {3}$", legH[0].idotartam, legH[0].taxi_id, legH[0].tavolsag, legH[0].viteldij);

        }


        public void HibasAdatokFileba()
        {
            var hibaLista = fuvarokLista.Where(x => (x.idotartam > 0 && x.viteldij > 0) && x.tavolsag == 0).OrderBy(x=>x.indulas).ToList();

            using (var sw = new StreamWriter("hiba.txt", false, Encoding.UTF8))
            {
                sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                hibaLista.ForEach(x => sw.WriteLine(
                                                x.taxi_id + ";" +
                                                x.indulas + ";" + 
                                                x.idotartam + ";" + 
                                                x.tavolsag + ";" + 
                                                x.viteldij + ";" + 
                                                x.borravalo + ";" + 
                                                x.fizetes_modja));
            }
        }

    }
}
