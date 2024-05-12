using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Půjčovna_Automobilů
{
    internal class Zakaznik
    {
        public int ID { get; set; }

        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        public string DatumNarozeni { get; set; }
        public int Vek { get; set; }

        public int Kontakt1 { get; set; }
        public int Kontakt2 { get; set; }
        public int Kontakt3 { get; set; }

        public string PujceneAuto { get; set; }

        public int VinPujcenehoAuta { get; set; }
        public string DatumPujceni { get; set; }
        public string DatumVraceni { get; set; }

        public double UtracenePenize { get; set; }
        public Zakaznik(int id, string jmeno, string prijmeni,string datumNarozeni, int vek,int kontakt1, int kontakt2, int kontakt3, string pujceneAuto, int vinPujcenehoAuta, string datumVraceni, string datumPujceni, double utracenePenize)
        {
            ID = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;

            DatumNarozeni = datumNarozeni;
            Vek = vek;

            Kontakt1 = kontakt1;
            Kontakt2 = kontakt2;
            Kontakt3 = kontakt3;
            PujceneAuto = pujceneAuto;
            VinPujcenehoAuta = vinPujcenehoAuta;

            DatumPujceni = datumPujceni;
            DatumVraceni = datumVraceni;

            UtracenePenize = utracenePenize;
        }
    }
}
