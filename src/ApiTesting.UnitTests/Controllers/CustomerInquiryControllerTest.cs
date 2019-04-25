using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ApiTesting.Services.Interface;
using ApiTesting.Services.Models;
using ApiTesting.Models;
using ApiTesting.Controllers;

namespace ApiTesting.UnitTests.Controllers
{
    [TestFixture]
    public class CustomerInquiryControllerTest
    {
        [Test]
        [TestCase("1", "joegerien@gmail.com")]
        [TestCase("2", "joegerien@gmail.com")]
        [TestCase(null, "joegerien@gmail.com")]
        [TestCase("2", "phongpheera.k@gmail.com")]
        public void Post_RequestIsValid_ResponseOK(string customerID, string email)
        {
            CustomerInquiryController controller = new CustomerInquiryController(FakeCustomerInquityServiceForPost(5));
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var request = new CustomerInquiryRequest()
            {
                customerID = customerID,
                email = email
            };

            var result = controller.Post(request);

            Assert.That(result.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase(null, "")]
        [TestCase("test", null)]
        public void Post_RequestIsInvalid_ResponseBadRequest(string customerID, string email)
        {
            CustomerInquiryController controller = new CustomerInquiryController(FakeCustomerInquityServiceForPost(5));
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var request = new CustomerInquiryRequest()
            {
                customerID = customerID,
                email = email
            };

            var result = controller.Post(request);

            Assert.That(result.StatusCode == HttpStatusCode.BadRequest); ;
        }

        private ICustomerInquiryService FakeCustomerInquityServiceForPost(int transactionRow)
        {
            var customerInquityService = Substitute.For<ICustomerInquiryService>();

            var customerDto = new CustomerDto();
            customerDto = GenerateFakeCustomerDto();
            for(var i = 0; i < transactionRow; i++)
            {
                customerDto.transactions.Add(GenerateFakeTransactionDto());
            }

            customerInquityService.GetCustomerTransaction(Arg.Any<int>(), Arg.Any<string>())
                                   .Returns<CustomerDto>(customerDto);

            return customerInquityService;
        }

        private CustomerDto GenerateFakeCustomerDto()
        {
            return new CustomerDto()
            {
                customerID = 7,
                name = "David Michael",
                email = "TestEmail@Tesla.com",
                mobile = "0812234567",
                transactions = new List<TransactionDto>()
            };
        }

        private TransactionDto GenerateFakeTransactionDto()
        {
            return new TransactionDto()
            {
                id = 77,
                date = new DateTime(),
                amount = 150,
                currency = "THB",
                status = "Success"
            };
        }
    }
}
