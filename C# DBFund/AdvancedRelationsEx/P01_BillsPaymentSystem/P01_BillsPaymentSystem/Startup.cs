using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Initializer;

namespace P01_BillsPaymentSystem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                Console.WriteLine("Enter userId:");
                int userId = int.Parse(Console.ReadLine());

                Console.WriteLine("Parsing data...");

                User user = GetUser(userId, context);

                if (user == null)
                {
                    Console.WriteLine($"User with id {userId} not found!");
                }
                else
                {
                    PrintInfo(user);
                }

                Console.WriteLine();
                Console.WriteLine("Enter the amount of moeny you wish to pay:");
                PayBills(user, decimal.Parse(Console.ReadLine()), context);
            }
        }

        private static void PayBills(User user, decimal amount, BillsPaymentSystemContext context)
        {
            var bankAccountsTotals =
                user.PaymentMethods.Where(x => x.BankAccount != null).Sum(x => x.BankAccount.Balance);
            var creditCardsTotals =
                user.PaymentMethods.Where(x => x.CreditCard != null).Sum(x => x.CreditCard.LimitLeft);

            var totalAvailableFunds = bankAccountsTotals + creditCardsTotals;

            if (totalAvailableFunds >= amount)
            {
                var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null)
                    .Select(x => x.BankAccount).OrderBy(x => x.BankAccountId).ToArray();

                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        bankAccount.Withdraw(amount);
                        amount = 0;

                        context.SaveChanges();
                    }
                    else
                    {
                        amount -= bankAccount.Balance;
                        bankAccount.Withdraw(bankAccount.Balance);

                        context.SaveChanges();
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }

                var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null)
                    .Select(x => x.CreditCard).OrderBy(x => x.CreditCardId).ToArray();

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;

                        context.SaveChanges();
                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);

                        context.SaveChanges();
                    }

                    if (amount == 0)
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        private static void PrintInfo(User user)
        {
            var bankAccounts = user.PaymentMethods.Where(u => u.BankAccount != null).Select(u => u.BankAccount);
            var creditCards = user.PaymentMethods.Where(u => u.CreditCard != null).Select(u => u.CreditCard);

            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts:");

            foreach (var bankAccount in bankAccounts.OrderBy(x => x.BankAccountId))
            {
                Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                Console.WriteLine($"--- Balance: {bankAccount.Balance:f2}");
                Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                Console.WriteLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            Console.WriteLine("Credit Cards:");

            foreach (var creditCard in creditCards.OrderBy(x => x.CreditCardId))
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit:f2}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwned:f2}");
                Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft:f2}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
            }
        }

        private static User GetUser(int userId, BillsPaymentSystemContext context)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault();

            return user;
        }
    }
}
