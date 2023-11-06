using System;
using System.Collections.Generic;
using System.Text;

namespace Szoftverek
{
    class Szoftver
    {
        public int Azonosito { get; set; }
        public string NevEsVerzio { get; set; }
        public string LicenszTipus { get; set; }
        public string[] TamogatottOSek { get; set; }
        public string Kategoria { get; set; }
        public double Ertekeles { get; set; }
        public double NettoAr { get; set; }
        public int AdoKulcs { get; set; }
        //9. feladat
        public double BruttoAr => NettoAr + NettoAr * AdoKulcs / 100.0;

        public Szoftver(string sor)
        {
            string[] adatok = sor.Split('|');
            this.Azonosito = int.Parse(adatok[0]);
            this.NevEsVerzio = adatok[1];
            this.LicenszTipus = adatok[2];
            this.TamogatottOSek = adatok[3].Split(", ");
            this.Kategoria = adatok[4];
            this.Ertekeles = double.Parse(adatok[5]);
            this.NettoAr = double.Parse(adatok[6]);
            this.AdoKulcs = int.Parse(adatok[7]);
        }

        public override string ToString()
        {
            return $"{this.Azonosito}|{this.NevEsVerzio}|{this.LicenszTipus}|{String.Join(", ", this.TamogatottOSek)}|{this.Kategoria}|{this.Ertekeles}|{this.NettoAr}|{this.Ertekeles}";
        }
    }
}
