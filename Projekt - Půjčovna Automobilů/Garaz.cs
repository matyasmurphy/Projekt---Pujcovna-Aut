using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    internal class Garaz
    {
        public List<Auto> auta = new List<Auto>();


        Random random = new Random();
        public void PridatAuto() //potom vic vozidel, lepe napsat
        {
            int vin = random.Next(10000, 99999);

            foreach (Auto item in auta) // zajišťuje, aby se nevygenerovalo stejné VIN více krát
            {
                while (vin == item.VIN)
                {
                    vin = random.Next(10000, 99999);
                }
            }

            int spz = random.Next(1000, 9999);

            foreach (Auto item in auta) // zajišťuje, aby se nevygenerovalo stejné SPZ více krát
            {
                while (spz == item.VIN)
                {
                    spz = random.Next(1000, 9999);
                }
            }

            Console.Write("Vyrobce: ");
            string vyrobce = Console.ReadLine();

            Console.Write("Model auta: ");
            string model = Console.ReadLine();

            Console.Write("Rok vyroby: ");
            int rokVyroby = int.Parse(Console.ReadLine());

            Console.Write("Cena za den: ");
            int cenaZaDen = int.Parse(Console.ReadLine());

            bool dostupnost = true;

            int stavTachometru = 0;

            Console.Write("Pocet mist: ");
            int pocetMist = int.Parse(Console.ReadLine());

            string kdoSiPujcilAuto = "null";

            Auto auto = new Auto(vin, spz, vyrobce, model, rokVyroby, cenaZaDen, dostupnost, stavTachometru, pocetMist, kdoSiPujcilAuto);
            auta.Add(auto);
        }
        public void VypisAuta()
        {
            int i = 0;
            foreach (Auto item in auta)
            {
                i++;
                Console.WriteLine("Seznam Aut: ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{i}. Auto: ");
                Console.WriteLine($"VIN: {item.VIN}");
                Console.WriteLine($"SPZ: XXX:{item.SPZ}");
                Console.WriteLine($"Vyrobce: {item.Vyrobce}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Rok vyroby: {item.RokVyroby}");
                Console.WriteLine($"Cena za den: {item.CenaZaDen}");
                if (item.Dostupnost == true)
                    Console.WriteLine($"Dostupnost: Dostupny");
                if (item.Dostupnost == false)
                {
                    Console.WriteLine($"Dostupnost: Pujceny");
                    Console.WriteLine($"Pucil/a si ho: {item.KdoSiPujcilAuto}");
                }
                Console.WriteLine($"Stav tachometru: {item.StavTachometru}km");
                Console.WriteLine($"Pocet mist: {item.PocetMist}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();

                Console.Write("Pokračujte stiskem libovolné klávesy...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public void VymazAuto()
        {
            Console.WriteLine("Seznam aut");
            for (int i = 0; i < auta.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Auto: {auta[i].Model}");
            }
            Console.WriteLine("Jake z nich chces prodat?");

            int indexDel = int.Parse(Console.ReadLine()) - 1;

            if (indexDel >= 0 && indexDel <= auta.Count)
            {
                Console.WriteLine($"{auta[indexDel].Model} bylo prodano");
                auta.RemoveAt(indexDel);
            }
        }
    }
}
