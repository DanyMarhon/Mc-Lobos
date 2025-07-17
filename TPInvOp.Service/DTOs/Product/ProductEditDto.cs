namespace TPInvOp.Service.DTOs.Product
{
    public class ProductEditDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public bool IsActive { get; set; }
    }
}
