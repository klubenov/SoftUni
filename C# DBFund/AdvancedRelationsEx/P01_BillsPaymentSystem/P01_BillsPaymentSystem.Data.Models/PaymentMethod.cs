﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P01_BillsPaymentSystem.Data.Models.Attributes;
using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Pmch(nameof(BankAccountId))]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
