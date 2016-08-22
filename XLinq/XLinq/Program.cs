using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var mscorlibAssembly = Assembly.Load("mscorlib");
            var mscorlibXML = CreateXml(mscorlibAssembly);
            //mscorlibXML.Save("mscorlib.xml");
            exexercise3a(mscorlibXML);
            exexercise3b(mscorlibXML);
            exexercise3c(mscorlibXML);
            exexercise3d(mscorlibXML);
            exexercise3e(mscorlibXML);

            Console.ReadKey();

        }
        private static XElement CreateXml(Assembly assembly)
        {
            var root = new XElement("Root");
            foreach (var type in assembly.GetTypes().Where(t => t.IsClass).Where(t => t.IsPublic))
            {
                var xmlType = new XElement("Type", new XAttribute("FullName", type.FullName));
                var xmlProperties = new XElement("Properties");
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    xmlProperties.Add(new XElement("Property", new XAttribute("Name", property.Name), new XAttribute("Type", property.PropertyType.FullName == null ? property.PropertyType.Name : property.PropertyType.FullName)));
                xmlType.Add(xmlProperties);
                var xmlMethods = new XElement("Methods");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => !m.GetBaseDefinition().Equals(m)))
                {
                    var xmlMethod = new XElement("Method", new XAttribute("Name", method.Name), new XAttribute("ReturnType", method.ReturnType.FullName == null ? method.ReturnType.Name : method.ReturnType.FullName));
                    var xmlParameters = new XElement("Parameters");
                    foreach (var parameter in method.GetParameters())
                        xmlParameters.Add(new XElement("Parameter", new XAttribute("Name", parameter.Name), new XAttribute("Type", parameter.ParameterType)));
                    xmlMethod.Add(xmlParameters);
                    xmlMethods.Add(xmlMethod);
                }
                xmlType.Add(xmlMethods);
                root.Add(xmlType);
            }
            return root;
        }
        private static void exexercise3a(XElement xml)
        {
            var typeWithoutProperty = xml.Descendants("Type").Where(x => x.Elements("Properties").Elements().Count() == 0).OrderBy(x => x.Attribute("Name")).ToList();
            Console.WriteLine(typeWithoutProperty.Count());
            foreach (var item in typeWithoutProperty)
                Console.WriteLine(item.Attribute("FullName").Value);
        }
        private static void exexercise3b(XElement xml)
        {
            Console.WriteLine($"total number {xml.Descendants("Method").Count()}");
        }
        private static void exexercise3c(XElement xml)
        {
            Console.WriteLine($"Properties: {xml.Descendants("Property").Count()}");
            var commonParamete = xml.Descendants("Parameter").GroupBy(x => x.Attribute("Type").Value).OrderBy(x => x.Key).First();
            Console.WriteLine($"{commonParamete.Key} -> {commonParamete.Key.Length}");
        }
        private static void exexercise3d(XElement xml)
        {
            var root = new XElement("Types", xml.Descendants("Type").OrderBy(x => x.Descendants("Method").Count()).Reverse().
                Select(x => new XElement("Method", new XAttribute("TypeName", x.Attributes().First().Value),
                new XAttribute("ProprtyNumber", x.Descendants("Property").Count()), new XAttribute("MethodsNumber", x.Descendants("Method").Count()))));
            root.Save("exexercise3d.xml");
        }
        private static void exexercise3e(XElement xml)
        {
            xml.Descendants("Type").GroupBy(x => x.Descendants("Method").Count()).OrderBy(x => x.Key).Reverse().
                Select(x=> x.OrderBy(y=>y.Attribute("FullName").Value));
        }
    }
}