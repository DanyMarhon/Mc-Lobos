using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using TPInvOp.Model.Entities;
using TPInvOp.Web.ViewModels.Locality;

namespace TPInvOp.Web.ViewModels.Customer
{
    public class CustomerEditVm
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }

        public string? ContactPhone { get; set; }
        public string? DeliveryAddress { get; set; }
        [DisplayName("Locality")]
        public int LocalityId { get; set; }
        [ValidateNever]
        public List<SelectListItem> Localities { get; set; } = null!;
    }
}
