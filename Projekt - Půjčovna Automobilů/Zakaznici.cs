using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    internal class Zakaznici
    {
        //private List<Auto> auta = new List<Auto>();
        public List<Zakaznik> zakaznici = new List<Zakaznik>();
        Random random = new Random();

        public void PridatZakaznika(List<Auto> auta)
        {
            int id = random.Next(10000, 99999);

            foreach (Auto item in auta) // zajišťuje, aby se nevygenerovalo stejné ID více krát
            {
                while (id == item.VIN)
                {
                    id = random.Next(10000, 99999);
                }
            }
            Console.Write("Jmeno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Prijmeni: ");
            string prijmeni = Console.ReadLine();

            Console.Write("Datum narozeni (YYYY/MM/DD): ");
            string datumNarozeni = Console.ReadLine();

            int vek = 0;

            if (System.DateTime.TryParse(datumNarozeni, out System.DateTime birthDate))
            {
                // Calculate the age
                vek = SpocitejVek(birthDate, System.DateTime.Today);
            }
            else
            {
                Console.WriteLine("Spatne zadano");
            }

            int kontakt1 = random.Next(100, 999);
            foreach (Zakaznik item in zakaznici) // zajišťuje, aby se nevygeneroval stejný kontakt více krát
            {
                while (kontakt1 == item.Kontakt1)
                {
                    kontakt1 = random.Next(100, 999);
                }
            }
            int kontakt2 = random.Next(100, 999);
            foreach (Zakaznik item in zakaznici) // zajišťuje, aby se nevygeneroval stejný kontakt více krát
            {
                while (kontakt2 == item.Kontakt2)
                {
                    kontakt2 = random.Next(100, 999);
                }
            }
            int kontakt3 = random.Next(100, 999);
            foreach (Zakaznik item in zakaznici) // zajišťuje, aby se nevygeneroval stejný kontakt více krát
            {
                while (kontakt3 == item.Kontakt3)
                {
                    kontakt3 = random.Next(100, 999);
                }
            }

            string pujceneAuto = "Zadne";

            int vinPujcenehoAuta = 0;

            string datumPujceni = "null";
            string datumVraceni = "null";

            double utracenePenize = 0;

            Zakaznik zakaznik = new Zakaznik(id, jmeno, prijmeni, datumNarozeni, vek, kontakt1, kontakt2, kontakt3, pujceneAuto, vinPujcenehoAuta, datumPujceni, datumVraceni, utracenePenize);
            zakaznici.Add(zakaznik);
        }

        public void VypsatZakazniky()
        {
            int i = 0;
            foreach (Zakaznik item in zakaznici)
            {
                i++;
                Console.WriteLine("Seznam zakazniku:");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{i}. Zakaznik");
                Console.WriteLine($"ID: {item.ID}");
                Console.WriteLine($"Jmeno: {item.Jmeno}");
                Console.WriteLine($"Prijmeni: {item.Prijmeni}");
                Console.WriteLine($"Datum narozeni: {item.DatumNarozeni}");
                Console.WriteLine($"Vek: {item.Vek}");
                Console.WriteLine($"Kontakt: +420 {item.Kontakt1} {item.Kontakt2} {item.Kontakt3}");
                Console.WriteLine($"Pujcene auto: {item.PujceneAuto}");
                Console.WriteLine($"Utracene penize: {item.UtracenePenize} Kc");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();

                Console.Write("Pokračujte stiskem libovolné klávesy...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public void VymazZakaznika()
        {
            Console.WriteLine("Seznam zakazniku");
            for (int i = 0; i < zakaznici.Count; i++)
            {
                Console.WriteLine($"{1}. Zakaznik: {zakaznici[i].Jmeno} {zakaznici[i].Prijmeni}");
            }
        }
        static int SpocitejVek(System.DateTime birthDate, System.DateTime currentDate)
        {
            int vek = currentDate.Year - birthDate.Year;

            // Zkontroluje, zda narozeniny uz letos byly
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                vek--;
            }

            return vek;
        }
    }
}
