using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle: Shape, IPersist, IComparable
    {
        private double _width;
        private double _height;
        public override double Area
        {
            get
            {
                return _width * _height;
            }
        }
        public Rectangle(double width,double height)
        {
            _width = width;
            _height = height;
        }
        public override void Display()
        {
            Console.WriteLine("I'm Rectangle:");
            Console.WriteLine("The width is "+ _width);
            Console.WriteLine("The height is " + _height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("The width is "+ _width);
            sb.AppendLine("The height is " + _height);
        }

        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
            {
                var area = (obj as Rectangle).Area;
                if (Area > area)
                    return 1;
                if (Area == area)
                    return 0;
                return -1;
            }
            throw new NotImplementedException();
        }
    }
}
