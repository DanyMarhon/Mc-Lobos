using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInvOp.Model.DTOs.PaymentMethod
{
    public class PaymentMethodDTO
    {
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
