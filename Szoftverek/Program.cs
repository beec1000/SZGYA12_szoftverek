using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Szoftverek
{
    class Program
    {
        static List<Szoftver> F7(List<Szoftver> sz)
        {
            return sz.Where(d => d.Kategoria == "antivírus" && d.Ertekeles > 8.5).ToList();
        }

        static List<Szoftver> F8(List<Szoftver> sz)
        {
            var max = sz.Max(jsz => jsz.Ertekeles - 0.1);
            return sz.Where(d => d.Ertekeles == max).ToList();
        }

        static double F10(List<Szoftver> sz)
        {
            return sz.Where(d => d.NevEsVerzio.StartsWith("Adobe")).Average(ave => ave.BruttoAr);
        }

        static string[] F11(List<Szoftver> sz)
        {
            List<string> k = sz.Where(d => d.TamogatottOSek.Length == 2).GroupBy(d => d.Kategoria).Select(d => d.First().Kategoria).ToList();
            k.Sort();
            return k.ToArray();
        }

        static List<Szoftver> F12(List<Szoftver> sz)
        {
            return sz.Where(d => d.NettoAr > 500 && d.Ertekeles < 9).ToList();
        }

        static void Main(string[] args)
        {
            var szoftverek = new List<Szoftver>();

            using var sr = new StreamReader(@"..\..\..\src\szoftverek.txt");
            {
                _ = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    szoftverek.Add(new Szoftver(sr.ReadLine()));
                }
            }

            Console.WriteLine("6. feladat");
            foreach (var i in szoftverek)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("7. feladat");
            List<Szoftver> antivirusok = F7(szoftverek);
            Console.WriteLine(antivirusok.Count);

            Console.WriteLine("8. feladat");
            List<Szoftver> joSzoftverek = F8(szoftverek);
            foreach (var i in joSzoftverek)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("10.feladat");
            Console.WriteLine(F10(szoftverek));

            Console.WriteLine("11. feladat");
            var f11 = F11(szoftverek);
            if (f11.Length == 0) 
                Console.WriteLine("HIBA 404!!!");
            else 
                Console.WriteLine(string.Join(", ", f11));

            Console.WriteLine("12.feladat");
            var f12 = F12(szoftverek);
            if (f12.Count == 0) 
                Console.WriteLine("HIBA 404!!!");
            else 
                Console.WriteLine(string.Join(", ", f12.Select(d => d.Azonosito)));

            //13. feladat
            using var sw = new StreamWriter(@"..\..\..\src\fizetos.txt");
            {
                var f13 = szoftverek.Where(sz => sz.LicenszTipus == "fizetős").ToList();
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine(f13[i]);
                }
            }
        }
    }
}
