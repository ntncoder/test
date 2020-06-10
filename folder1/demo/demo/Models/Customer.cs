using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Models
{
    public class Customer
    {
        public Guid customerID { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string city { get; set; }
        public string birthday { get; set; }
        public string mobile { get; set; }
    }
}
