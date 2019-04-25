using System;
using NUnit.Framework;
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
        [TestCase(2, "phongpheera.k@gmail.com")]
        public void Post_IsSuccess(string customerID, string email)
        {
            CustomerInquiryController controller = new CustomerInquiryController();

            var request = new CustomerInquiryRequest();
            request.customerID = customerID;
            request.email = email;

            var result = controller.Post(request);

            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("0", "")]
        [TestCase(null, null)]
        [TestCase(2, "phong@gmail.com")]
        public void Post_NotSuccess(string customerID, string email)
        {
            CustomerInquiryController controller = new CustomerInquiryController();

            var request = new CustomerInquiryRequest();
            request.customerID = customerID;
            request.email = email;

            var result = controller.Post(request);

            Assert.IsNull(result);
        }
    }
}
