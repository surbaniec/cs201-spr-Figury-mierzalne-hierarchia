using System;
using System.Collections.Generic;
using FiguryLib;


namespace Figury
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Proste testy konstrukcji i modyfikacji: Okrag2D");
            Okrag2D o1 = new Okrag2D();
            Console.WriteLine(o1);
            o1.Rysuj();
            Console.WriteLine(o1.ToString(Format.Pelny));
            o1.Nazwa = "o1";
            o1.O = new Punkt2D(2, 2);
            o1.R = 2;
            Console.WriteLine(o1.ToString(Format.Pelny));

            Console.WriteLine("\n--- Proste testy: Kolo2D");
            Kolo2D k1 = new Kolo2D(srodek: new Punkt2D(1, 1), promien: 2);
            k1.Rysuj();
            Console.WriteLine(k1.ToString(Format.Pelny));

            Console.WriteLine("--- --- rzutowanie koła na okrąg");
            Okrag2D o2 = (Okrag2D)k1;
            Console.WriteLine(o2.ToString(Format.Pelny));

            Console.WriteLine("--- --- konwersja koła na okrąg");
            Okrag2D o2_1 = k1.ToOkrag2D();
            Console.WriteLine(o2_1.ToString(Format.Pelny));

            Console.WriteLine("--- --- konwersja okręgu na koło");
            Kolo2D k2 = o1.ToKolo2D();
            Console.WriteLine(k2.ToString(Format.Pelny));

            Console.WriteLine("--- --- przesuwanie, skalowanie");
            k2.Przesun(1, 1);
            Console.WriteLine($"Po przesunięciu {k2.Nazwa}: {k2.ToString(Format.Pelny)}");

            k2.Skaluj(2);
            Console.WriteLine($"Po skalowaniu {k2.Nazwa}: {k2.ToString(Format.Pelny)}");


            Console.WriteLine("\n--- Proste testy: Sfera, Kula");
            Sfera s1 = new Sfera(new Punkt3D(1, -1, 0), promien: 2);
            Console.WriteLine(s1.ToString(Format.Pelny));
            Kula ku1 = new Kula();
            Console.WriteLine(ku1.ToString(Format.Pelny));
            ku1.R = 3;
            ku1.Rysuj();

            Kula ku2 = new Kula(srodek: Punkt3D.ZERO, promien: 1);
            Sfera s2 = ku2.ToSfera(); //konwersja kuli na sferę
            s2.R = 2;
            Console.WriteLine(s2.ToString(Format.Pelny));
            var ku3 = s2.ToKula(); //konwersja sfery na kulę

            var o3 = (Okrag2D)s2; //rzutowanie sfery na okrąg
            Console.WriteLine(o3.ToString(Format.Pelny));

            var o4 = (Okrag2D)ku2; //rzutowanie kuli na okrąg
            Console.WriteLine(o4.ToString(Format.Pelny));

            var k3 = (Kolo2D)ku2; //rzutowanie kuli na koło
            Console.WriteLine(o4.ToString(Format.Pelny));

            Console.WriteLine("\n ** Lista Figur **");
            List<Figura> lista = new List<Figura> { o1, k1, o2, o2_1, k2, s1, ku1, ku2, s2, ku3, o3, o4, k3 };
            foreach (var x in lista)
                x.Rysuj();

            List<double> listaDlugosci = new List<double> { o1.Dlugosc, k1.Dlugosc, o2.Dlugosc, o2_1.Dlugosc, k2.Dlugosc, o3.Dlugosc, o4.Dlugosc, k3.Dlugosc };
            List<double> listaPol = new List<double> { k1.Pole, k1.Pole, k2.Pole, s1.Pole, ku1.Pole, ku2.Pole, s2.Pole, ku3.Pole, k3.Pole };
            List<double> listaObjetosci = new List<double> { ku1.Objetosc, ku2.Objetosc, ku3.Objetosc };

            double sredniaDlugosc = 0;

            foreach(double d in listaDlugosci)
            {
                sredniaDlugosc += d;
            }
            sredniaDlugosc = sredniaDlugosc / listaDlugosci.Count;

            double sumarycznePole = 0;

            foreach (double p in listaPol)
            {
                sumarycznePole += p;
            }

            double maksymalnaObjetosc = listaPol[0];

            foreach (double d in listaDlugosci)
            {
                if (d > maksymalnaObjetosc) maksymalnaObjetosc = d;
            }

            Console.WriteLine($"Średnia długość figur = {sredniaDlugosc} ");
            Console.WriteLine($"Sumaryczne pole figur = {sumarycznePole} ");
            Console.WriteLine($"Objętość figury największej = {maksymalnaObjetosc} ");
        }
    }
}