using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Product
{
    public class ProductEditVm
    {
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        [DisplayName("Is Active")]
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public bool IsActive { get; set; }
    }
}
