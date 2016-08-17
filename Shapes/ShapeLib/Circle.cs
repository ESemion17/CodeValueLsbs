using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(double Radius) : base(Radius, Radius)
        {
        }
        public override void Display()
        {
            Console.WriteLine("I'm Circle:");
            Console.WriteLine("The radius is " + _radius1);

        }
    }
}
