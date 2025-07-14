using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Customer
{
    public class CustomerListVm
    {
        public int CustomerId { get; set; }

        [DisplayName("Customer")]
        public string? CustomerName { get; set; }
        public string? ContactPhone { get; set; }
        [DisplayName("Delivery Address")]
        public string? DeliveryAddress { get; set; }
        [DisplayName("Locality")]
        public string LocalityName { get; set; } = null!;
    }
}
