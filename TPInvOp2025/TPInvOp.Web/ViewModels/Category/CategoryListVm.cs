using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Category
{
    public class CategoryListVm
    {
        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}
