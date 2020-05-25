using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuvarGyakProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            FuvarokRepository repo = new FuvarokRepository();

            //3. feladat
            Console.WriteLine("3. feladat: {0} fuvar", repo.Count());

            //4. feladat
            Console.Write("4. feladat: ");
            repo.BevetelAzonositoAlapjan();

            //5.feladat
            Console.WriteLine("5. feladat");
            repo.FizetesiModokStatisztika();

            //6. feladat
            Console.Write("6. feladat: " + repo.OsszMegtettKilometer() + "km");

            //7. feladat
            Console.WriteLine("7. feladat: Leghosszabb fuvar:");
            repo.LeghosszabbFuvar();

            //8. feladat
            repo.HibasAdatokFileba();
            Console.WriteLine("8. feladat: hiba.txt");

            Console.ReadKey();
        }
    }
}
