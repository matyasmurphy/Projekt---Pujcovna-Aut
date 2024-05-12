using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    internal class Soubor
    {
        public void UlozitDoSouboru(string filePath, List<Auto> auta, List<Zakaznik> zakaznici)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Auto item in auta)
                {
                    writer.WriteLine($"{item.VIN},{item.SPZ},{item.Vyrobce},{item.Model},{item.RokVyroby},{item.CenaZaDen},{item.Dostupnost},{item.StavTachometru},{item.PocetMist},{item.KdoSiPujcilAuto}");
                }
            }
            Console.WriteLine("Data byla úspěšně uložena do souboru.");
        }

        public void NacistZeSouboru(string filePath, List<Auto> auta, List<Zakaznik> zakaznici)
        {
            if (File.Exists(filePath))
            {
                auta.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 10)
                        {
                            string vinStr = parts[0];
                            int vin = Int32.Parse(vinStr);
                            string spzStr = parts[1];
                            int spz = Int32.Parse(spzStr);
                            string vyrobce = parts[2];
                            string model = parts[3];
                            string rokVyrobyStr = parts[4];
                            int rokVyroby = Int32.Parse(rokVyrobyStr);
                            string cenaZaDenStr = parts[5];
                            int cenaZaDen = Int32.Parse(cenaZaDenStr);
                            string dostupnostStr = parts[6];
                            bool dostupnost = bool.Parse(dostupnostStr);
                            string stavTachometruStr = parts[7];
                            int stavTachometru = Int32.Parse(stavTachometruStr);
                            string pocetMistStr = parts[8];
                            int pocetMist = Int32.Parse(pocetMistStr);
                            string kdoSiPujcilAuto = parts[9];
                            Auto auto = new Auto(vin, spz, vyrobce, model, rokVyroby, cenaZaDen, dostupnost, stavTachometru, pocetMist, kdoSiPujcilAuto);
                            auta.Add(auto);
                        }
                    }
                }
                Console.WriteLine("Data byla úspěšně načtena ze souboru.");
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }
    }
}
