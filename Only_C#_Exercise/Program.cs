using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    class Snooker
    {
        public int helyezes;
        public string nev;
        public string orszag;
        public int nyeremeny;
        public Snooker(string s)
        {
            string[] sor = s.Split(';');
            helyezes = int.Parse(sor[0]);
            nev = sor[1];
            orszag = sor[2];
            nyeremeny = int.Parse(sor[3]);
        }
    }
    class snooker
    {
        public string elsosor;
        List<Snooker> lista = new List<Snooker>();
        public snooker()
        {
            StreamReader sr = new StreamReader("snooker.txt");
            elsosor = sr.ReadLine();
            while(!sr.EndOfStream)
            {
                lista.Add(new Snooker(sr.ReadLine()));
            }
            sr.Close();
        }
        public void feladat3()
        {
            Console.WriteLine("3. feladat: A világranglistán "+lista.Count()+" versenyző szerepel");
        }
        public void feladat4()
        {
            var atlag = lista.Select(x => x.nyeremeny).Average();
            Console.WriteLine("4. feladat: A versenyzők átlagosan {0} fontot kerestek",atlag);
        }
        public void feladat5()
        {
            Console.WriteLine("5. feladat: A legjobban kereső kínai versenyző:");
            var legjobb = lista.Where(x => x.orszag == "Kína").Max(x => x.nyeremeny);
            foreach (var item in lista)
            {
                if(item.nyeremeny==legjobb)
                {
                    Console.WriteLine("\tHelyezés: {0} \n\tNév: {1} \n\tOrszág: {2} \n\tNyeremény összege: {3} Ft", item.helyezes, item.nev, item.orszag, item.nyeremeny*380);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            snooker s = new snooker();
            s.feladat3();
            s.feladat4();
            s.feladat5();
            Console.ReadKey();

        }
    }
}
