using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    class Pujcka
    {
        public DateTime DatumPujcky { get; set; }
        public DateTime DatumVraceni { get; set; }

        bool checkDostupnost = false; //jestli se vyskutuje pujcene auto v listu. False = nevyskytuje, True = vyskytuje

        public void PujcitAuto(List<Auto> auta, List<Zakaznik> zakaznici)
        {
            VypisUkazkuZakazniku(zakaznici);
            Console.Write("Jaky zakaznik si pujci auto: ");
            int vyber1 = int.Parse(Console.ReadLine()) - 1;

            if (zakaznici[vyber1].Vek >= 18)
            {
                Console.Clear();
                VypisUkazkuAuta(auta);
                Console.Write("Jake auto si zakaznik pujci: ");
                int vyber2 = int.Parse(Console.ReadLine()) - 1;
                if (vyber2 <= auta.Count && vyber2 >= 0)
                {
                    Console.Write($"Vybrali jste: ");
                    Console.WriteLine($"{auta[vyber2].Model}");
                    zakaznici[vyber1].PujceneAuto = auta[vyber2].Model;
                    auta[vyber2].Dostupnost = false;
                    auta[vyber2].KdoSiPujcilAuto = zakaznici[vyber1].Jmeno + " " + zakaznici[vyber1].Prijmeni;
                    zakaznici[vyber1].VinPujcenehoAuta = auta[vyber2].VIN;

                    Console.Write("Kdy si auto pujcuje (YYYY/MM/DD): ");
                    string datumPujcky = Console.ReadLine();
                    zakaznici[vyber1].DatumVraceni = datumPujcky;
                    DateTime datumPujckyDateTime = DateTime.Parse(datumPujcky);
                    DatumPujcky = datumPujckyDateTime;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{zakaznici[vyber1].Jmeno} {zakaznici[vyber1].Prijmeni} nema ridicak");
                PujcitAuto(auta,zakaznici);
            }
            
        }
        public void VratitAuto(List<Auto> auta, List<Zakaznik> zakaznici)
        {
            foreach (Auto item in auta)
            {
                if (item.Dostupnost == false) // Dostupnost == false znamena ze nejake auto je pujcene
                {
                    checkDostupnost = true;
                }
                else
                {
                    checkDostupnost = false;
                }
            }

            if (checkDostupnost == true)
            {
                Random random = new Random();
                VypisUkazkuZakazniku(zakaznici);
                Console.Write("Kdo bude vracet auto: ");
                int indexVratit = int.Parse(Console.ReadLine()) - 1;
                if (indexVratit <= zakaznici.Count && indexVratit >= 0)
                {
                    int x = 0; //vin auta,ktery si pujcil 
                    int y = 0;
                    while (zakaznici[indexVratit].VinPujcenehoAuta != x)
                    {
                        for (int j = 0; j < auta.Count; j++)
                        {
                            x = auta[j].VIN;
                            y = j;
                        }
                    }
                    auta[y].Dostupnost = true; //zjistit index auta
                    zakaznici[indexVratit].PujceneAuto = "Zadne";
                    auta[y].StavTachometru = auta[y].StavTachometru + random.Next(50, 151);

                    Console.Write("Kdy bylo auto vracene (YYYY/MM/DD): ");
                    string datumVraceni = Console.ReadLine();
                    zakaznici[indexVratit].DatumVraceni = datumVraceni;

                    DateTime datumVraceniDateTime = DateTime.Parse(datumVraceni);
                    DatumVraceni = datumVraceniDateTime;

                    TimeSpan casPujcky = DatumVraceni - DatumPujcky;

                    Console.WriteLine($"{zakaznici[indexVratit].Jmeno} {zakaznici[indexVratit].Prijmeni} mel auto pujcene {casPujcky.TotalDays} dni");

                    double cenaZaPujcku = auta[y].CenaZaDen * casPujcky.TotalDays;
                    zakaznici[indexVratit].UtracenePenize = zakaznici[indexVratit].UtracenePenize + cenaZaPujcku;
                    Console.WriteLine($"Cena za pujcku: {cenaZaPujcku} Kc");

                    Console.Write("Pokračujte stiskem libovolné klávesy...");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            }
            else
            {
                Console.WriteLine("Nikdo si nepujcil auto");
            }
        }

        private void VypisUkazkuAuta(List<Auto> auta)
        {
            int i = 0;
            foreach (Auto item in auta)
            {
                i++;
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{i}. Auto: ");
                Console.WriteLine($"Model: {item.Model}");
                if (item.Dostupnost == true)
                    Console.WriteLine($"Dostupnost: Dostupny");
                if (item.Dostupnost == false)
                {
                    Console.WriteLine($"Dostupnost: Pujceny");
                    Console.WriteLine($"Pucil/a si ho: {item.KdoSiPujcilAuto}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        private void VypisUkazkuZakazniku(List<Zakaznik> zakaznici)
        {
            int i = 0;
            foreach (Zakaznik item in zakaznici)
            {
                i++;
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{i}. Zakaznik: ");
                Console.WriteLine($"Jmeno: {item.Jmeno} {item.Prijmeni}");
                Console.WriteLine($"Pujcene auto: {item.PujceneAuto}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
