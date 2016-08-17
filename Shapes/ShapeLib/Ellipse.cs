using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        protected double _radius1;
        protected double _radius2;
        public Ellipse(double Radius1, double Radius2)
        {
            _radius1 = Radius1;
            _radius2 = Radius2;
        }
        public override double Area
        {
            get
            {
                return Math.PI * _radius1*_radius2;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
            {
                var area = (obj as Ellipse).Area;
                if (Area > area)
                    return 1;
                if (Area == area)
                    return 0;
                return -1;
            }
            throw new NotImplementedException();
        }

        public override void Display()
        {
            Console.WriteLine("I'm Ellipse:");
            Console.WriteLine("The first radius is " + _radius1);
            Console.WriteLine("The second radius is " + _radius2);
        }
        public void Write(StringBuilder sb)
        {
            sb.AppendLine("The first radius is " + _radius1);
            sb.AppendLine("The second radius is " + _radius2);
        }
    }
}
