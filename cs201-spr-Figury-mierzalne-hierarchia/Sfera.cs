using System;
using System.Collections.Generic;
using System.Text;

namespace FiguryLib
{
    public class Sfera : Figura3D, IMierzalna2D
    {
        public Punkt3D O;
        public double R;

        public Sfera() : base() {}

        public Sfera(Punkt3D punkt, double promien = 0, string nazwa = "") : base(nazwa)
        {
            O = punkt;
            R = promien;
        }

        public double Pole => 4* Math.PI * Math.Pow(R,2);

        public override void Przesun(double dx, double dy, double dz)
        {
            O = new Punkt3D(O.X + dx, O.Y + dy, O.Z + dz);
        }

        public override void Przesun(Wektor3D kierunek)
        {
            O = new Punkt3D(O.X + kierunek.X, O.Y+ kierunek.Y, O.Z + kierunek.Z);
        }

        public void Skaluj(double wspSkalowania)
        {
            R = R * wspSkalowania * wspSkalowania;
        }

        public virtual string ToString(Format format) => (format is Format.Prosty) ?
          this.ToString()
        : $"{base.ToString()}, Sfera({O}), ({R}), Pole = {Pole}";

        public Kula ToKula() => new Kula(O, R, Nazwa);

        public virtual Okrag2D ToOkrag2D() => new Okrag2D(new Punkt2D(O.X, O.Y), R, Nazwa);

        public static explicit operator Okrag2D(Sfera v) => v.ToOkrag2D();


    }
}
