using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class BankAccountInitializer
    {
        public static BankAccount[] GetBankAccounts()
        {
            BankAccount[] bankAccounts =
            {
                new BankAccount(1000, "TBI", "wow"),
                new BankAccount(2000, "FIB", "shit"),
                new BankAccount(3000, "UBB", "toss"),
                new BankAccount(4000, "OBB", "whoops")
            };

            return bankAccounts;
        }
    }
}
