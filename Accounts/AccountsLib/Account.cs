using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        private int _id;
        private decimal _balance;
        public Account(int id)
        {
            _id = id;
            _balance = 0;
        }
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public void Deposit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();
            _balance += (decimal)amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > 0)
                throw new ArgumentOutOfRangeException();
            if (_balance < (decimal)amount)
                throw new InsufficientFundsException();
            _balance -= (decimal)amount;
        }
        public double Balance
        {
            get
            {
                return (double)_balance;
            }
        }
        public void Transfer(Account a1, double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();
            var b1 = Balance;
            var b2 = a1.Balance;
            try
            {
                Withdraw(amount);
                a1.Deposit(amount);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Balance in your account befor the transfer is {b1}");
                Console.WriteLine($"Balance in {a1} account befor the transfer is {b2}");
                Console.WriteLine($"Balance in your account after the transfer is {Balance}");
                Console.WriteLine($"Balance in {a1} account after the transfer is {a1.Balance}");
            }
            
            
        }
        public override string ToString()
        {
            return "Your account id is: " + _id + "\t,Your balance is: " + _balance;
        }
    }
}
