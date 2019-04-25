using ApiTesting.Services.Models;

namespace ApiTesting.Services.Interface
{
    public interface ICustomerInquiryService
    {
        CustomerDto GetCustomerTransaction(int customerID, string email);
    }
}
