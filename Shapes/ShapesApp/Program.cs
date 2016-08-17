using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeManager = new ShapeManager();
            shapeManager.Add(new Circle(2));
            shapeManager.Add(new Rectangle(10,2));
            shapeManager.Add(new Rectangle(12.4, 21.9));
            shapeManager.Add(new Ellipse(1, 2));
            shapeManager.Add(new Circle(3));
            shapeManager.DisplayAll();
            Console.WriteLine();
            var sb=new StringBuilder();
            shapeManager.Save(sb);
            Console.WriteLine(sb.ToString());

        }
    }
}
