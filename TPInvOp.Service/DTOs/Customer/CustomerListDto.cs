namespace TPInvOp.Service.DTOs.Customer
{
    public class CustomerListDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public string? LocalityName { get; set; }
    }
}
