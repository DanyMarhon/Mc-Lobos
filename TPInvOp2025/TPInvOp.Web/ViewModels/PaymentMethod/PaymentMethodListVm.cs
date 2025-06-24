using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.PaymentMethod
{
    public class PaymentMethodListVm
    {
        public int PaymentMethodID { get; set; }
        [DisplayName("Payment Method Name")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
    }
}
