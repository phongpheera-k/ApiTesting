using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ApiTesting.Models;
using ApiTesting.Services.Implementation;
using ApiTesting.Services.Interface;
using ApiTesting.Services.Models;

namespace ApiTesting.Controllers
{
    public class CustomerInquiryController : ApiController
    {
        private readonly ICustomerInquiryService customerInquiryService;

        public CustomerInquiryController()
            : this(new CustomerInquiryService()) { }

        public CustomerInquiryController(ICustomerInquiryService customerInquiryService)
        {
            this.customerInquiryService = customerInquiryService;
        }

        [HttpPost]
        public HttpResponseMessage Post(CustomerInquiryRequest request)
        {
            HttpResponseMessage result;

            try
            {
                var errorMessage = default(string);
                if (IsValidGetRequest(request, out errorMessage))
                {
                    var customerTrans = new CustomerInquiryResponse();
                    var customerID = string.IsNullOrWhiteSpace(request.customerID) ? 0 : int.Parse(request.customerID);
                    customerTrans.customer = this.customerInquiryService.GetCustomerTransaction(customerID, request.email);
                    if (customerTrans.customer != null)
                    {
                        result = Request.CreateResponse(HttpStatusCode.OK, customerTrans.customer);
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.OK, "Not found");
                    }
                }
                else
                {
                    switch(errorMessage)
                    {
                        case "No inquiry criteria":
                            result = result = Request.CreateResponse(HttpStatusCode.BadRequest, "");
                            break;
                        case "Invalid Customer ID":
                            result = result = Request.CreateResponse(HttpStatusCode.BadRequest, "");
                            break;
                        default:
                            result = result = Request.CreateResponse(HttpStatusCode.BadRequest, "");
                            break;
                    }
                }
            }
            catch (ArgumentException arg)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, arg.Message);
            }
            catch (Exception)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }

            return result;
        }

        private bool IsValidGetRequest(CustomerInquiryRequest request, out string errorMessage)
        {
            errorMessage = default(string);

            if (string.IsNullOrWhiteSpace(request.customerID) && string.IsNullOrWhiteSpace(request.email))
            {
                errorMessage = "No inquiry criteria";
            }

            if (!string.IsNullOrWhiteSpace(request.customerID))
            {
                if (!IsNumeric(request.customerID))
                {
                    errorMessage = "Invalid Customer ID";
                }
            }
            return string.IsNullOrWhiteSpace(errorMessage);
        }

        private bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
