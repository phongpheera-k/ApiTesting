using System;
using System.Collections.Generic;
using System.Linq;
using ApiTesting.Repository.EntityModel;

namespace ApiTesting.Repository.Repository
{
    class CustomerInquiryRepository
    {
        public List<Customer> GetData(int customerId, string customerEmail)
        {
            var customers = new List<Customer>();
            using (var context = new ApiTestingEntities())
            {
                customers = context.Customers.Where(x => x.Customer_ID == customerId || x.Contact_Email == customerEmail).ToList();
            }
            return customers;
        }
    }
}
