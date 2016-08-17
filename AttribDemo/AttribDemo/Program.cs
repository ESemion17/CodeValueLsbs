using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if(AnalayzeAssembly(Assembly.GetExecutingAssembly()))
                Console.WriteLine("All type was Code Approved");
            else
                Console.WriteLine("Not all type was Code Approved");

            //AnalayzeAssembly(Assembly.LoadFrom(@"C:\Users\Semion\Documents\visual studio 2015\Projects\DynInvoke\DynInvoke\bin\Debug\DynInvoke.exe"));
            //OR better
            //AnalayzeAssembly(Assembly.LoadFrom(@"..\..\..\..\DynInvoke\DynInvoke\bin\Debug\DynInvoke.exe"));
            //It did nothing because this assembly file not contain CodeReviewAttribute on any type
        }

        static bool AnalayzeAssembly(Assembly assembly)
        {
            bool flag = true;
            foreach (var type in assembly.GetTypes())
            {
                foreach (var att in type.GetCustomAttributes(typeof(CodeReviewAttribute), false))
                {
                    var tmp = (CodeReviewAttribute)att;
                    Console.WriteLine("Name: " + tmp.Name);
                    Console.WriteLine("Date: " + tmp.Data);
                    Console.WriteLine("Is Code Approved: " + tmp.CodeApproved);
                    Console.WriteLine();
                    flag &= tmp.CodeApproved;
                }
            }
            return flag;
        }
    }
}
