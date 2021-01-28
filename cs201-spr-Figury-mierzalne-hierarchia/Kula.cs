using System;
using System.Collections.Generic;
using System.Text;

namespace FiguryLib
{
    public class Kula : Sfera, IMierzalna2D, IMierzalna3D
    {

        public Kula() : base() { }

        public Kula(Punkt3D srodek, double promien, string nazwa = "") : base(srodek, promien, nazwa) {}

        public double Objetosc => 4D/3D * Math.PI * Math.Pow(R,3);

        public override string ToString() => $"Kula({O}, {R})";

        public override string ToString(Format format)
            => (format is Format.Prosty) ?
                  this.ToString()
                : $"{base.ToString().Replace("Sfera", "Kula")}, Objętość = {Objetosc}";

        public Sfera ToSfera() => new Sfera(O, R, Nazwa);
        public static explicit operator Okrag2D(Kula v) => v.ToOkrag2D();
        public virtual Kolo2D ToKolo2D() => new Kolo2D(new Punkt2D(O.X, O.Y), R, Nazwa);

        public static explicit operator Kolo2D(Kula v) => v.ToKolo2D();
    }
}
