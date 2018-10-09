using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class PaymentMethodInitializer
    {
        public static PaymentMethod[] GetPaymentMethods()
        {
            PaymentMethod[] paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod() {UserId = 1, BankAccountId = 1, Type = PaymentType.BankAccount},
                new PaymentMethod() {UserId = 1, CreditCardId = 1, Type = PaymentType.CreditCard},
                new PaymentMethod() {UserId = 2, BankAccountId = 2, Type = PaymentType.BankAccount},
                new PaymentMethod() {UserId = 2, CreditCardId = 2, Type = PaymentType.CreditCard},
                new PaymentMethod() {UserId = 3, BankAccountId = 3, Type = PaymentType.BankAccount},
                new PaymentMethod() {UserId = 3, CreditCardId = 3, Type = PaymentType.CreditCard},
                new PaymentMethod() {UserId = 4, BankAccountId = 4, Type = PaymentType.BankAccount},
                new PaymentMethod() {UserId = 4, CreditCardId = 4, Type = PaymentType.CreditCard},
            };

            return paymentMethods;
        }
    }
}
