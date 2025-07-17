namespace TPInvOp.Service.DTOs.Product
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
