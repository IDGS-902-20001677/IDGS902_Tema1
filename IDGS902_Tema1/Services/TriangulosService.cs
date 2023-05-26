using IDGS902_Tema1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS902_Tema1.Services
{
    public class TriangulosService
    {
        public void Calcular(Triangulo t)
        {
            //Lado AB = √((x₂ -x₁)² +(y₂ -y₁)²)
            //Lado BC = √((x₃ -x₂)² +(y₃ -y₂)²)
            //Lado CA = √((x₁ -x₃)² +(y₁ -y₃)²)
            double distance1 = Math.Round(Math.Abs(Math.Sqrt((Math.Pow((t.X2 - t.X1), 2) + Math.Pow((t.Y2 - t.Y1), 2)))), 2);
            double distance2 = Math.Round(Math.Abs(Math.Sqrt((Math.Pow((t.X3 - t.X2), 2) + Math.Pow((t.Y3 - t.Y2), 2)))), 2);
            double distance3 = Math.Round(Math.Abs(Math.Sqrt((Math.Pow((t.X1 - t.X3), 2) + Math.Pow((t.Y1 - t.Y3), 2)))), 2);
            var distances = new List<double> { distance1, distance2, distance3 };
            var maxDistance = distances.Max();
            distances.Remove(maxDistance);
            var sumDistances = distances.Sum();
            if (maxDistance < sumDistances)
            {
                bool equalSides = distance1 == distance2 && distance2 == distance3;
                bool diferrentSides = distance1 != distance2 && distance2 != distance3;
                if (equalSides)
                {
                    t.Type = "Equilatero";
                }
                else if (diferrentSides)
                {
                    t.Type = "Escaleno";
                }
                else
                {
                    t.Type = "Isoceles";
                }
                //s = (Lado AB + Lado BC + Lado CA) / 2
                var s = (distance1 + distance2 + distance3) / 2;
                //A = √(s(s - Lado AB)(s - Lado BC)(s - Lado CA))
                //var area = Math.Abs(s * (s - distance1) * (s - distance2) * (X1 - distance3));
                //Area = Math.Sqrt(area);
                t.Area = 0.5 * Math.Abs((t.X1 * (t.Y2 - t.Y3) + t.X2 * (t.Y3 - t.Y1) + t.X3 * (t.Y1 - t.Y2)));
            }
            else
            {
                t.Type = "No es un triangulo";
            }
        }
    }
}