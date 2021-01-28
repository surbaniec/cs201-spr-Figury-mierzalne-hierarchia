using System;
using System.Collections.Generic;
using System.Text;

namespace FiguryLib
{
    public class Okrag2D : Figura2D, IMierzalna1D
    {
        public Punkt2D O;
        public double R;

        public Okrag2D() : base() {}

        public Okrag2D(Punkt2D srodek, double promien = 0, string nazwa = "") : base(nazwa)
        {
            this.O = srodek;
            this.R = promien;
        }

        public double Dlugosc => 2 * Math.PI * R;

        public override void Przesun(double dx, double dy)
        {
            O = new Punkt2D(O.X + dx, O.Y + dy);
        }

        public override void Przesun(Wektor2D kierunek)
        {
            O = new Punkt2D(O.X + kierunek.X, O.Y + kierunek.Y);
        }

        public override string ToString()
        {
            return $"Okrag2D({O}, {R})";
        }

        public virtual string ToString(Format format)
        {
            return (format is Format.Prosty) ?
                  this.ToString()
                : $"{base.ToString()}, Okrag2D({O}, {R}), Długość = {Dlugosc:0.##}";
        }

        public void Skaluj(double wspSkalowania)
        {
            R = R * wspSkalowania * wspSkalowania;
        }

        public Kolo2D ToKolo2D() => new Kolo2D(O, R, Nazwa);
    }
}
