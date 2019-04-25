using System;
using System.Collections.Generic;
using System.Linq;
using ApiTesting.Repository.EntityModel;
using ApiTesting.Domain.CustomerInquiry;
using System.Reflection;

namespace ApiTesting.Repository.Repository
{
    public class CustomerInquiryRepository : ICustomerInquiryRepository
    {
        public CustomerModel GetData(int customerId, string customerEmail)
        {
            var customer = new Customer();
            var transactions = new List<Transaction>();
            using (var context = new ApiTestingEntities())
            {
                customer = context.Customers.Where(x => x.Customer_ID == customerId && x.Contact_Email == customerEmail).FirstOrDefault();
                transactions = customer.Transactions.ToList();
            }
            var result = ConvertEntityCustomerToBusinessObject(customer, new CustomerModel());
            result.Transaction = new List<TransactionModel>();
            foreach(var tran in transactions)
            {
                result.Transaction.Add(ConvertEntityTransactionToBusinessObject(tran, new TransactionModel()));
            }
            return result;
        }

        private CustomerModel ConvertEntityCustomerToBusinessObject(Customer entityObject, CustomerModel businessObject)
        {
            Type BusinessObjectType = businessObject.GetType();
            PropertyInfo[] BusinessPropList = BusinessObjectType.GetProperties();

            Type EntityObjectType = entityObject.GetType();
            PropertyInfo[] EntityPropList = EntityObjectType.GetProperties();

            foreach (PropertyInfo businessPropInfo in BusinessPropList)
            {
                foreach (PropertyInfo entityPropInfo in EntityPropList)
                {
                    if (entityPropInfo.Name == businessPropInfo.Name)
                    {
                        businessPropInfo.SetValue(businessObject, entityPropInfo.GetValue(entityObject, null), null);
                        break;
                    }
                }
            }

            return businessObject;
        }

        private TransactionModel ConvertEntityTransactionToBusinessObject(Transaction entityObject, TransactionModel businessObject)
        {
            Type BusinessObjectType = businessObject.GetType();
            PropertyInfo[] BusinessPropList = BusinessObjectType.GetProperties();

            Type EntityObjectType = entityObject.GetType();
            PropertyInfo[] EntityPropList = EntityObjectType.GetProperties();

            foreach (PropertyInfo businessPropInfo in BusinessPropList)
            {
                foreach (PropertyInfo entityPropInfo in EntityPropList)
                {
                    if (entityPropInfo.Name == businessPropInfo.Name)
                    {
                        businessPropInfo.SetValue(businessObject, entityPropInfo.GetValue(entityObject, null), null);
                        break;
                    }
                }
            }

            return businessObject;
        }
    }
}
