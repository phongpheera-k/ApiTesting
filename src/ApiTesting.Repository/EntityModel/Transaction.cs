namespace ApiTesting.Repository.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Transaction_ID { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }
        public decimal Customer_ID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Currency_Code { get; set; }
        public Nullable<byte> Status { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
