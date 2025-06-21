using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPInvOp.Web.ViewModels.Category
{
    public class CategoryListVm
    {
        public int CategoryId { get; set; }
        [DisplayName ("Category")]
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
