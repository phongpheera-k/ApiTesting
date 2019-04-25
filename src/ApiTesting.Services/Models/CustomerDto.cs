using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.Services.Models
{
    public class CustomerDto
    {
        public int customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public List<TransactionDto> transactions { get; set; }
    }
}
