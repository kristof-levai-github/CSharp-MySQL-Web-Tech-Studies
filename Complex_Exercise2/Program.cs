using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoiTenisz
{
    class Noi
    {
        public string torna;
        public DateTime datum;
        public string burkolat;
        public string eredmeny;
        public string gyoztesneve;
        public string gyoztesmagassaga;
        public string gyoztesnemzetisege;
        public double gyozteseletkora;
        public string vesztesneve;
        public string vesztesmagassaga;
        public string vesztesnemzetisege;
        public double veszteseletkora;
        public Noi(string s)
        {
            string[] sor = s.Split(';');
            torna = sor[0];
            datum = DateTime.Parse(sor[1]);
            burkolat = sor[2];
            eredmeny = sor[3];
            gyoztesneve = sor[4];
            gyoztesmagassaga = sor[5];
            gyoztesnemzetisege = sor[6];
            gyozteseletkora = double.Parse(sor[7]);
            vesztesneve = sor[8];
            vesztesmagassaga = sor[9];
            vesztesnemzetisege = sor[10];
            veszteseletkora = double.Parse(sor[11]);
        }
    }
    class NoiTenisz
    {
        public List<Noi> lista = new List<Noi>();
        public NoiTenisz()
        {
            StreamReader sr = new StreamReader("noitenisz.csv");
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                lista.Add(new Noi(sr.ReadLine()));
            }
        }
        public void feladat3()
        {
            foreach (var item in lista)
            {
                if(item.vesztesneve=="Tamira Paszek")
                {
                    Console.WriteLine("3. feladat: nem");
                    break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NoiTenisz n = new NoiTenisz();
            n.feladat3();
            Console.ReadKey();
        }
    }
}
