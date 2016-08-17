using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement: DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement xElement)
        {
            _element = xElement;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object res)
        {
            var elemnt = _element.Element(binder.Name);
            res = null;
            if (elemnt != null)
            {
                res = new DynamicXElement(elemnt);
                return true;
            }
            return false;

        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var elemnt = _element.Element(binder.Name);
            if (elemnt != null)
            {
                elemnt.SetValue(value);
                return true;
            }
            return false;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object res)
        {
            res = new DynamicXElement(null);
            int index;
            if ((indexes.Length == 2) && (indexes[0] is string) && (int.TryParse(indexes[1].ToString(), out index)))
            {
                var allNodes = _element.Elements(indexes[0].ToString());
                if (index < allNodes.Count())
                {
                    res = new DynamicXElement(allNodes.ElementAt(index));
                    return true;
                }
            }
            return false;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            int index;
            if ((indexes.Length == 2) && (indexes[0] is string) && (int.TryParse(indexes[1].ToString(), out index)))
            {
                var allNodes = _element.Elements(indexes[0].ToString());
                allNodes.ElementAt(index).SetValue(value);
                return true;
            }
            else
                return false;
        }
        
        public override string ToString()
        {
            return _element.Value;
        }
        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }
    }
}




