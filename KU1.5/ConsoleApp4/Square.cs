
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Square : Shapes
    {
        public double Length { get; set; }

        public override double FindArea()
        {
            return Length * Length;
        }

        public override double FindPerimeter()
        {
            return Length + Length + Length + Length;
        }
    }
}
