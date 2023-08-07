using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EU
{
    class eu
    {
        public string nev;
        public DateTime csatlakozas;
        public eu( string s)
        {
            string[] sor = s.Split(";");
            nev = sor[0];
            csatlakozas = DateTime.Parse(sor[1]);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List<eu> lista = new List<eu>();
            StreamReader sr = new StreamReader("EUcsatlakozas.txt");
            while(!sr.EndOfStream)
            {
                lista.Add(new eu(sr.ReadLine()));
            }
            sr.Close();
            //3. feladat
            int osszeg = lista.Count;
            Console.WriteLine("3. feladat: EU tagállamainak száma: {0} db",osszeg);
            //4.feladat
            var ketezerhet = lista.Where(x => x.csatlakozas.Year == 2007).Count();
            Console.WriteLine("4. feladat: 2007-ben {0} ország csatlakozott.",ketezerhet);
            //5.feladat
            foreach (var item in lista)
            {
                if (item.nev == "Magyarország")
                    Console.WriteLine("5. feladat: Magyarország csatlakozásának dátuma: {0}", item.csatlakozas.ToShortDateString());
            }
            //6.feladat
            int db = 0;
            foreach (var item in lista)
            {
                if (item.csatlakozas.Month == 05)
                    db++;
            }
            if(db!=0)
                Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
            else
                Console.WriteLine("6. feladat: Májusban NEM volt csatlakozás!");
            //7.feladat
            var sorszam = lista.OrderByDescending(x => x.csatlakozas).Select(x=>x.nev).First();
            Console.WriteLine("7. feladat: Legutoljára csatlakozott ország: {0}",sorszam);
            Console.ReadKey();
            //8.feladat
            Console.Write("8. feladat: Statisztika");
            var csoport = lista.GroupBy(x => x.csatlakozas, y => y.nev,(csatlakozas, nev)=>new {key=csatlakozas.Year, value=nev.Count()});
            foreach (var item in csoport)
            {
                Console.WriteLine(item.key + "-"+ item.value);
            }

        }
    }
}
