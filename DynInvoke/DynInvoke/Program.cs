using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Console.WriteLine(InvokeHello(a, "semion"));
            Console.WriteLine(InvokeHello(b, "epelman"));
            Console.WriteLine(InvokeHello(c, "S.E"));
        }
        public static string InvokeHello(Object obj,string st)
        {
            return (string) obj.GetType().GetMethod("Hello").Invoke(obj, new object[] { st });
        }
    }
    public class A
    {
        public string Hello (string st)
        {
            return "Hello " + st;
        }
    }
    public class B
    {
        public string Hello(string st)
        {
            return "Bonjour " + st;
        }
    }
    public class C
    {
        public string Hello(string st)
        {
            return "Nihau " + st;
        }
    }
}
