using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kektura
{
    class Kektura
    {
        public string kiindulopont;
        public string vegpont;
        public double hossz;
        public int emelkedes;
        public int leejtes;
        public string pecsetelohely;
        public Kektura(string s)
        {
            string[] sor = s.Split(';');
            kiindulopont = sor[0];
            vegpont = sor[1];
            hossz = double.Parse(sor[2]);
            emelkedes = int.Parse(sor[3]);
            leejtes = int.Parse(sor[4]);
            pecsetelohely = sor[5];
                  
        }
    }

    class kektura
    {
        public int tengerfeletti;
        List<Kektura> lista = new List<Kektura>();
        public kektura()
            {
                StreamReader sr = new StreamReader("kektura.csv");
                tengerfeletti=int.Parse(sr.ReadLine());
                while(!sr.EndOfStream)
                {
                lista.Add(new Kektura(sr.ReadLine()));
                }
                sr.Close();
            }
        public void feladat3()
        {
            Console.WriteLine("3. feladat: Szakaszok száma: "+lista.Count()+" db");
        }
        public void feladat4()
        {
            Console.WriteLine("4. feladat: A túra teljes hossza: "+lista.Select(x=>x.hossz).Sum()+" km");
        }
        public void feladat5()
        {
            Console.WriteLine("5. feladat: A legrövidebb szakasz adatai:");
            var legrovidebb = lista.Min(x => x.hossz);
            foreach (var item in lista)
            {
                if(item.hossz==legrovidebb)
                {
                    Console.WriteLine("\tKezdte: {0} \n\tVége: {1} \n\tTávolság: {2} km", item.kiindulopont, item.vegpont, item.hossz);
                }
            }
        }
        public bool HianyosNev()
        {
            foreach (var item in lista)
            {
                if (item.pecsetelohely=="i" && !item.vegpont.Contains("pecsetlohely"))
                    return true;
                else
                    return false;
            }
        }
        public void feladat6()
        {
            
        }
        public void feladat7()
        {
            Console.WriteLine("7. feladat: Hiányos állomásnevek:");
        }
        public void feladat8()
        {
            Console.WriteLine("8. feladat: A túra legmagassabban fekvő végpontja:");
            var legmagassab = lista.Max(x => x.emelkedes + tengerfeletti - x.leejtes);
            foreach (var item in lista)
            {
                if(item.emelkedes+tengerfeletti-item.leejtes==legmagassab)
                {
                    Console.WriteLine("\tA végpont neve {0} \n\tA végpont tengerszint feletti magassága: {1} m",item.vegpont,legmagassab);
                }
            }
        }
        public void feladat9()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            kektura k = new kektura();
            k.feladat3();
            k.feladat4();
            k.feladat5();
            k.feladat6();
            k.feladat7();
            k.feladat8();
            k.feladat9();
            Console.ReadKey();
        }
    }
}
