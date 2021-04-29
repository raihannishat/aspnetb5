using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class BankAccount
    {
        public delegate void AccountDelegate();
        public event AccountDelegate AccountEnent;

        public void WithdrawBalance(int amount)
        {
            Console.WriteLine($"Withdraw is called and amount is {amount}");
            AccountEnent();
        }
    }
}
