using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.Services.Models
{
    public class TransactionDto
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
    }
}
