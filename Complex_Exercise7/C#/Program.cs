using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Berek
{
    class Berek
    {
        public string nev;
        public string neme;
        public string reszleg;
        public int belepes;
        public int ber;
        public Berek(string s)
        {
            string[] sor = s.Split(';');
            nev = sor[0];
            neme = sor[1];
            reszleg = sor[2];
            belepes = int.Parse(sor[3]);
            ber = int.Parse(sor[4]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Berek> lista = new List<Berek>();
            StreamReader sr = new StreamReader("berek2020.txt");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                lista.Add(new Berek(sr.ReadLine()));
            }
            sr.Close();
            //3. feladat
            double osszeg = lista.Count();
            Console.WriteLine("3. feladat: Dolgozók száma: {0} fő", osszeg);
            //4. feladat
            var beratlag = lista.Sum(x => x.ber)/osszeg/1000;
            Console.WriteLine("4. feladat: Bérek átlaga: {0:f1} eFT", beratlag);
            //5. feladat
            Console.Write("5. feladat: Kérem egy részleg nevét: ");
            string reszleg;
            reszleg=Console.ReadLine();
            //6. feladat

            //7. feladat
            Console.Write("7. feladat: Statisztika");
            var csoport = lista.GroupBy(x => x.reszleg=>new { key = reszleg, value = reszleg.Count());
            foreach (var item in csoport)
            {
                Console.WriteLine(item.key + "-" + item.value + "fő");
            }
            Console.ReadKey();
        }
    }
}
