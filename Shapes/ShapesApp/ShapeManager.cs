using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{

    class ShapeManager
    {
        private List<Shape> _shapes;
        public ShapeManager()
        {
            _shapes = new List<Shape>();
        }
        public void Add(Shape s)
        {
            _shapes.Add(s);
        }
        public void DisplayAll()
        {
            foreach (var shape in _shapes)
            {
                shape.Display();
                Console.WriteLine("The area is " + shape.Area);
            }
        }
        public Shape this[int i]
        {
            get
            {
                return _shapes[i];
            }
        }
        public int Count
        {
            get
            {
                return _shapes.Count;
            }
        }
        public void Save(StringBuilder sb)
        {
            foreach (var shape in _shapes)
                if (shape is IPersist)
                    (shape as IPersist).Write(sb);
        }
    }
}
