using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ApiTesting.Models;

namespace ApiTesting.UnitTests.Controllers
{
    [TestClass]
    public class CustomerInquiryControllerTest
    {
        [TestMethod]
        [TestCase("1", "joegerian@gmail.com")]
        [TestCase(null, "joegerian@gmail.com")]
        [TestCase(2, "phongpheera.k@gmail.com")]
        public void Post_Success(string customerID, string email)
        {
            CustomerInquiryControllerTest controller = new CustomerInquiryControllerTest();

            //var result = controller.post 
        }
    }
}
