using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    internal class Auto
    {
        public int VIN { get; set; }
        public int SPZ { get; set; }
        public string Vyrobce { get; set; }
        public string Model { get; set; }
        public int RokVyroby { get; set; }
        public int CenaZaDen { get; set; }
        public bool Dostupnost { get; set; }
        public int StavTachometru { get; set; }
        public int PocetMist { get; set; }
        public string KdoSiPujcilAuto { get; set; }

        public Auto(int vin, int spz, string vyrobce, string model, int rokVyroby, int cenaZaDen, bool dostupnost, int stavTachometru, int pocetMist, string kdoSiPujcilAuto)
        {
            VIN = vin;
            SPZ = spz;
            Vyrobce = vyrobce;
            Model = model;
            RokVyroby = rokVyroby;
            CenaZaDen = cenaZaDen;
            Dostupnost = dostupnost;
            StavTachometru = stavTachometru;
            PocetMist = pocetMist;
            KdoSiPujcilAuto = kdoSiPujcilAuto;
        }
    }
}
