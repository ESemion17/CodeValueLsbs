using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer: IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }

        public int CompareTo(Customer other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(Customer other)
        {
            return Name.Equals(other.Name) && ID.Equals(other.ID);
        }
        public override string ToString()
        {
            return $"Name: {Name}, ID: {ID}, Address: {Address}";
        }
    }
}
