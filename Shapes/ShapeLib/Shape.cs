using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected ConsoleColor _color;
        public Shape()
        {
            _color = ConsoleColor.White;
        }
        public Shape(ConsoleColor Color)
        {
            _color = Color;
        }
        public virtual void Display()
        {
            Console.ForegroundColor = _color;
        }
        public abstract double Area
        {
            get;
        }
    }
}
