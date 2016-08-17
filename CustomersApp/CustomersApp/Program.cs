using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);
    class Program
    {
        public static List<Customer> GetCustomers(List<Customer> list, CustomerFilter del)
        {
            var tmp = new List<Customer>();
            foreach (var item in list)
                if (del(item))
                    tmp.Add(item);
            return tmp;
        }
        public static bool CustomerStartsWithAToK(Customer customer)
        {
            for (int i = (int)'A'; i <= (int)'K'; ++i)
                if (customer.Name.StartsWith(((char)i).ToString()))
                    return true;
            return false;
        }
        public static bool CustomerStartsWithLToZ(Customer customer)
        {
            for (int i = (int)'L'; i <= (int)'Z'; ++i)
                if (customer.Name.StartsWith(((char)i).ToString()))
                    return true;
            return false;
        }
        static void Main(string[] args)
        {
            var customers = new Customer[6];
            customers[0] = new Customer();
            customers[0].ID = 2;
            customers[0].Name = "Semion";
            customers[1] = new Customer();
            customers[1].ID = 1;
            customers[1].Name = "Yossi";
            customers[2] = new Customer();
            customers[2].ID = 7;
            customers[2].Name = "Alon";
            customers[3] = new Customer();
            customers[3].ID = 4;
            customers[3].Name = "Ahmad";
            customers[4] = new Customer();
            customers[4].ID = 2;
            customers[4].Name = "Semion";
            customers[5] = new Customer();
            customers[5].ID = 102;
            customers[5].Name = "Epelman";
            var customerList = customers.ToList<Customer>();

            CustomerFilter aToKFilter = CustomerStartsWithAToK;
            var customer2 = GetCustomers(customerList, aToKFilter);
            Console.WriteLine("Customer A to K");
            foreach (var item in customer2)
                Console.WriteLine(item);

            CustomerFilter lToZFilter = CustomerStartsWithLToZ;
            var customer3 = GetCustomers(customerList, lToZFilter);
            Console.WriteLine("Customer L to Z");
            foreach (var item in customer3)
                Console.WriteLine(item);

            CustomerFilter idUnder100 = x=> x.ID<100;
            var customer4 = GetCustomers(customerList, idUnder100);
            Console.WriteLine("Customer with id under 100");
            foreach (var item in customer4)
                Console.WriteLine(item);

            Console.WriteLine("Befor sort");
            foreach (var item in customers)
                Console.WriteLine(item);
            //Array.Sort(customers);
            Array.Sort(customers, new AnotherCustomerComparer());
            Console.WriteLine("Afer sort");
            foreach (var item in customers)
                Console.WriteLine(item);
        }
    }
}
