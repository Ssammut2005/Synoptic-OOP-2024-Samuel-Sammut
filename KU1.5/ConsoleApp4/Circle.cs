
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Circle : Shapes
    {
        public double Radius { get; set; }

        public override double FindArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double FindPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
