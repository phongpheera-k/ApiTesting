using System;
using System.Collections.Generic;

namespace ApiTesting.Domain.CustomerInquiry
{
    public class TransactionModel
    {
        public int Transaction_ID { get; set; }
        public DateTime Transaction_Date { get; set; }
        public int Customer_ID { get; set; }
        public decimal Amount { get; set; }
        public string Currency_Code { get; set; }
        public byte Status { get; set; }
    }
}
