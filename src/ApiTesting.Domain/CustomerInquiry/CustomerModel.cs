using System;
using System.Collections.Generic;

namespace ApiTesting.Domain.CustomerInquiry
{
    public class CustomerModel
    {
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Contact_Email { get; set; }
        public string Mobile_No { get; set; }
        public List<TransactionModel> Transaction { get; set; }
    }
}
