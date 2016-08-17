using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace Main
{
    class Program
    {
        static void showMain()
        {
            Console.WriteLine("To Create new account prees 1");
            Console.WriteLine("To Deposit prees 2");
            Console.WriteLine("To Withdraw prees 3");
            Console.WriteLine("To Cheek balance prees 4");
            Console.WriteLine("To Transfer money press 5");
            Console.WriteLine("To See active accounts press 6");
            Console.WriteLine("To Exit prees 9");
        }
        static void Main(string[] args)
        {
            var accounts = new List<Account>();
            Console.WriteLine("Welcome to our bank");
            showMain();
            var ans = Console.ReadLine();
            while (!ans.Equals("9"))
            {
                double amount = -1;
                string AmountString;
                int IdNumber;
                switch (ans)
                {
                    case "1":
                        amount=-1;
                        Account tmpAccount;
                        Console.WriteLine("Please insert initial amount");
                        AmountString = Console.ReadLine();
                        while ((!double.TryParse(AmountString, out amount)) || ((tmpAccount = AccountFactory.CreateAccount(amount)) != null))
                        {
                            Console.WriteLine("Please insert correct amount");
                            AmountString = Console.ReadLine();
                        }
                        accounts.Add(tmpAccount);
                        break;
                    case "2":
                        
                        Console.WriteLine("Please insert ID number");
                        var IdString = Console.ReadLine();
                        while (!int.TryParse(IdString, out IdNumber))
                        {
                            Console.WriteLine("Please insert corrrct ID number");
                            IdString = Console.ReadLine();
                        }
                        Console.WriteLine("Please insert initial amount");
                        AmountString = Console.ReadLine();
                        amount = -1;
                        Console.WriteLine("Please insert amount to deposit");
                        AmountString = Console.ReadLine();
                        while (!double.TryParse(AmountString, out amount))
                        {
                            Console.WriteLine("Please insert correct amount");
                            AmountString = Console.ReadLine();
                        }
                        foreach (var item in accounts)
                        {
                            if (item.ID == IdNumber)
                                item.Deposit(amount);
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        foreach (var item in accounts)
                            Console.WriteLine(item);
                        break;
                    default:
                        Console.WriteLine("Wrong insert");
                        break;
                }
                showMain();
                ans = Console.ReadLine();
            }
        }
    }
}
