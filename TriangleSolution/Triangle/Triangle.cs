using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMain
{
    public enum TriangleType { Obtuse, RightAngled, Acute, NotTriangle }
        
    public class Triangle
    {        
        /// <summary>
        /// Side 1
        /// </summary>
        public double X1 { get; }

        /// <summary>
        /// Side 2
        /// </summary>
        public double X2 { get; }

        /// <summary>
        /// Side 3
        /// </summary>
        public double X3 { get; }

        public Triangle(double x1, double x2, double x3)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;
            
            ValidateTriangleSides();
        }

        /// <summary>
        /// Get type of triangle based on its three side lengths
        /// </summary>
        /// <returns></returns>
        public TriangleType GetTriangleType ()
        {
            if (!CheckIfItIsTriangle())
                return TriangleType.NotTriangle;

            return CalcTriangleType();
        }

        private TriangleType CalcTriangleType()
        {
            var sides = new List<double>() { X1, X2, X3 };
            sides.Sort();

            var maxSideSquare = Math.Pow(sides.Last(), 2);
            var otherSidesSquare = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);

            if(Math.Abs(maxSideSquare - otherSidesSquare) < AppSettings.Default.eps) 
                return TriangleType.RightAngled;

            if (maxSideSquare - otherSidesSquare > AppSettings.Default.eps) 
                return TriangleType.Obtuse;
            else return TriangleType.Acute;
        }

        /// <summary>
        /// Check if the triangle with given side lengths is existing
        /// </summary>
        /// <returns></returns>
        private bool CheckIfItIsTriangle()
        {
            if (X1 + X2 < X3 - AppSettings.Default.eps
                || X1 + X3 < X2 - AppSettings.Default.eps
                || X2 + X3 < X1 - AppSettings.Default.eps)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Check if side length values are correct
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ValidateTriangleSides()
        {
            double[] sides = new double[] { X1, X2, X3 };
            foreach (double side in sides)
            {
                if (side <= 0 || side.Equals(double.NaN)
                    || side.Equals(double.PositiveInfinity))
                    throw new ArgumentException
                        ($"Value of a side is not correct: side = [{side}]");
            }            
        }
    }
}
