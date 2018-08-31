using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class CreditCardInitializer
    {
        public static CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards =
            {
                new CreditCard(1000, 200, new DateTime(2020, 1, 1)),
                new CreditCard(2000, 300, new DateTime(2021, 1, 1)),
                new CreditCard(3000, 400, new DateTime(2022, 1, 1)),
                new CreditCard(4000, 500, new DateTime(2023, 1, 1))
            };

            return creditCards;
        }
    }
}
