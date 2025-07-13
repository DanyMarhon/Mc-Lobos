using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInvOp.Service.DTOs.Customer
{
    public class CustomerEditDto
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public int LocalityID { get; set; }
    }
}
