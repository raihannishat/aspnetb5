using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Transaction
    {
        private BankAccount _bankAccount;

        public Transaction()
        {
            _bankAccount = new BankAccount();
        }

        public void SendEmail()
        {
            Console.WriteLine("Email Send");
        }

        public void SendSMS()
        {
            Console.WriteLine("Email SMS");
        }

        public void WithdrawTransaction(int amount)
        {
            _bankAccount.AccountEnent += SendEmail;
            _bankAccount.AccountEnent += SendSMS;
            _bankAccount.WithdrawBalance(amount);
        }
    }
}
