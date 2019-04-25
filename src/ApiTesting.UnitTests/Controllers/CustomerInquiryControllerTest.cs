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
        [TestCase("1", "joegerian@gmail.com")]
        [TestCase(null, "joegerian@gmail.com")]
        [TestCase(2, "phongpheera.k@gmail.com")]
        public void Post_Success(string customerID, string email)
        {
            CustomerInquiryController controller = new CustomerInquiryController();

            var request = new CustomerInquiryRequest();
            request.customerID = customerID;
            request.email = email;

            var result = controller.Post(request);

            Assert.IsNotNull(result);
        }
    }
}
