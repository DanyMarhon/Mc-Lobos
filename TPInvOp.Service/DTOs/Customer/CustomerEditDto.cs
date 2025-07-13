namespace TPInvOp.Service.DTOs.Customer
{
    public class CustomerEditDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public int LocalityId { get; set; }
    }
}
