using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Customer
{
    public class CustomerEditVm
    {
        public int CustomerId { get; set; }
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        [DisplayName("Contact Phone")]
        public string? ContactPhone { get; set; }
        [DisplayName("Delivery Address")]
        public string? DeliveryAddress { get; set; }
        [DisplayName("Locality")]
        public int LocalityId { get; set; }
        [ValidateNever]
        public List<SelectListItem> Localities { get; set; } = null!;
    }
}
