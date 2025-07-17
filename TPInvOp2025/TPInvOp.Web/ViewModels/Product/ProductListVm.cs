using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Product
{
    public class ProductListVm
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; } = null!;
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
