using System;
using System.Collections.Generic;

namespace ApiTesting.Domain.CustomerInquiry
{
    public interface ICustomerInquiryRepository
    {
        CustomerModel GetData(int customerId, string customerEmail);
    }
}
