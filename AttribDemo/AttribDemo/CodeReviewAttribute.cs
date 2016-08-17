using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class CodeReviewAttribute : Attribute
    {
        public string Name { get; }
        public string Data { get; }
        public bool CodeApproved { get; }
        public CodeReviewAttribute(string name, string data, bool codeApproved)
        {
            Name = name;
            Data = data;
            CodeApproved = codeApproved;
        }
    }
}
