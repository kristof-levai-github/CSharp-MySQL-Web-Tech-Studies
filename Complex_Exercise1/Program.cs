using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Hidak
{
    class Hidak
    {
        public string nev;
        public string elhelyezkedes;
        public int tavolsag;
        public int atadas;
        public Hidak(string s)
        {
            string[] sor = s.Split(';');
            nev = sor[0];
            elhelyezkedes = sor[1];
            tavolsag = int.Parse(sor[2]);
            atadas = int.Parse(sor[3]);
        }
    }
    
    class hidak
    {

    }
    
    class Program
    {       
        static void Main(string[] args)
        {
            List<Hidak> lista = new List<Hidak>();
            StreamReader sr = new StreamReader("hidak.csv");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                lista.Add(new Hidak(sr.ReadLine()));
            }
            sr.Close();
            //3. feladat
            int szam = lista.Count;
            Console.WriteLine("3. feladat: Függőhidak száma az állományban: {0}",szam);
            //4. feladat
            var osszeg =lista.Where(x=>x.elhelyezkedes.Contains("Japán")).Count();
            Console.WriteLine("4. feladat: Függőhidak száma Japánban: {0}",osszeg);
            //5. feladat

            //6.feladat
            var legnagyobb = lista.Max(x => x.tavolsag);
            Console.WriteLine("6. feladat: A legnagyobb támaszközű híd adatai: ");
            Console.WriteLine("\tNév: {0} ");
            Console.WriteLine("\tElhelyezkedés: ");
            Console.WriteLine("\tTámaszköz: ");
            Console.WriteLine("\tÁtadás: ");


        }
    }
}
