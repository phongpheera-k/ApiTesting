namespace ApiTesting.Repository.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public decimal Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Contact_Email { get; set; }
        public string Mobile_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
