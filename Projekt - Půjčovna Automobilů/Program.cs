using System;
using System.Text;

namespace Projekt___Půjčovna_Automobilů
{
    //do souboru
    internal class Program
    {
        static void Main(string[] args)
        {

            Garaz garaz = new Garaz();
            Pujcka pujcka = new Pujcka();
            Zakaznici zakaznici = new Zakaznici();
            Soubor soubor = new Soubor();


            do
            {
                Console.Clear();
                Console.WriteLine(@" __  __   _   ___ _  _   __  __ ___ _  _ _   _ 
|  \/  | /_\ |_ _| \| | |  \/  | __| \| | | | |
| |\/| |/ _ \ | || .` | | |\/| | _|| .` | |_| |
|_|  |_/_/ \_\___|_|\_| |_|  |_|___|_|\_|\___/ 
");


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SPRAVA AUT");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(1) Pridat auto");
                Console.WriteLine("(2) Vypsat auta");
                Console.WriteLine("(3) Vymaz auta");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("SPRAVA ZAKAZNIKU");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(4) Pridat zakaznika");
                Console.WriteLine("(5) Vypsat zakazniky");
                Console.WriteLine("(6) Vymaz zakazniky");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("PUJCKA");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(7) Pujcit Auto");
                Console.WriteLine("(8) Vratit Auto");

                Console.WriteLine("SOUBOR");
                Console.WriteLine("(9) Ulozit");
                Console.WriteLine("(10) Nacist");

                int vyberMenu = int.Parse(Console.ReadLine());
                Console.Clear();

                string filePath;
                switch (vyberMenu)
                {
                    case 1:
                        garaz.PridatAuto();
                        break;

                    case 2:
                        garaz.VypisAuta();
                        break;
                    case 3:
                        garaz.VymazAuto();
                        break;
                    case 4:
                        zakaznici.PridatZakaznika(garaz.auta);
                        break;
                    case 5:
                        zakaznici.VypsatZakazniky();
                        break;
                    case 6:
                        zakaznici.VymazZakaznika();
                        break;
                    case 7:
                        pujcka.PujcitAuto(garaz.auta, zakaznici.zakaznici);
                        break;
                    case 8:
                        pujcka.VratitAuto(garaz.auta, zakaznici.zakaznici);
                        break;
                    case 9:
                        Console.WriteLine("Zadejte cestu k souboru pro uložení:");
                        filePath = Console.ReadLine();
                        soubor.UlozitDoSouboru(filePath, garaz.auta, zakaznici.zakaznici);
                        break;
                    case 10:
                        Console.WriteLine("Zadejte cestu k souboru pro načtení:");
                        filePath = Console.ReadLine();
                        soubor.NacistZeSouboru(filePath, garaz.auta, zakaznici.zakaznici);
                        break;
                }

            } while (true); // doesnt work because they are in separate classes for some reason. need to find out why
        }
    }
}