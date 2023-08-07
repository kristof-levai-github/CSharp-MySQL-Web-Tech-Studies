using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prost
{
    class Prost
    {
        public DateTime datum;
        public string verseny;
        public int helyezes;
        public int pont;
        public Prost(string s)
        {
            string[] sor = s.Split('\t');
            datum = DateTime.Parse(sor[0]);
            verseny = sor[1];
            helyezes = int.Parse(sor[2]);
            pont = int.Parse(sor[3]);
        }  
    }

    class Versenyzo
    {
        public List<Prost> lista = new List<Prost>();
        public Versenyzo()
        {
            StreamReader sr = new StreamReader("prost.csv");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                lista.Add(new Prost(sr.ReadLine()));
            }
        }

        public void Feladat3()
        {
            var befejezett = lista.Select(x => x.helyezes).Where(x => x != -1).Count();
            var indult = lista.Select(x => x.datum).Count();
            Console.WriteLine("3. feladat: {0}/{1}",befejezett,indult);
        }
        public void Feladat4()
        {
            Console.WriteLine("4. feladat:");
           

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Versenyzo v = new Versenyzo();
            v.Feladat3();
            v.Feladat4();
            Console.ReadKey();
        }
    }
}
