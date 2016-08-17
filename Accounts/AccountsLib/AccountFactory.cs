using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int _ids = 0;
        public static Account CreateAccount(double amount)
        {
            var acc = new Account(++_ids);
            acc.Deposit(amount);
            return acc;
        }
    }
}
