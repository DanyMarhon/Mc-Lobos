using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.PaymentMethod
{
    public class PaymentMethodEditVm
    {
        public int PaymentMethodId { get; set; }
        [DisplayName("Payment Method Name")]
        public string Name { get; set; } = null!;
        [DisplayName("Description")]
        public string? Description { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = false;
    }
}
