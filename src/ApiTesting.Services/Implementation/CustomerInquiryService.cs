using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTesting.Repository.Repository;
using ApiTesting.Domain.CustomerInquiry;
using ApiTesting.Services.Interface;
using ApiTesting.Services.Models;

namespace ApiTesting.Services.Implementation
{
    public class CustomerInquiryService : ICustomerInquiryService
    {
        public ICustomerInquiryRepository customerInquiryRepository;

        public CustomerInquiryService()
            : this(new CustomerInquiryRepository()) { }

        public CustomerInquiryService(ICustomerInquiryRepository customerInquiryRepository)
        {
            this.customerInquiryRepository = customerInquiryRepository;
        }

        public CustomerDto GetCustomerTransaction(int customerID, string email)
        {
            var result = new CustomerDto();

            var customerTrans = this.customerInquiryRepository.GetData(customerID, email);
            if(customerTrans != null)
            {
                result.customerID = customerTrans.Customer_ID;
                result.name = customerTrans.Customer_Name;
                result.email = customerTrans.Contact_Email;
                result.mobile = customerTrans.Mobile_No;
                if(customerTrans.Transaction != null)
                {
                    result.transactions = new List<TransactionDto>();
                    var transList = new TransactionDto();
                    foreach (var trans in customerTrans.Transaction)
                    {
                        transList = new TransactionDto();
                        transList.id = trans.Transaction_ID;
                        transList.date = trans.Transaction_Date;
                        transList.amount = trans.Amount;
                        transList.currency = trans.Currency_Code;
                        transList.status = trans.Status.ToString();
                        result.transactions.Add(transList);
                    }
                }
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}
