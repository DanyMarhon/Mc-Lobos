namespace TPInvOp.Service.DTOs.Product
{
    public class ProductListDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public bool IsActive { get; set; }
    }
}
