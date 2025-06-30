namespace TPInvOp.Service.DTOs.PaymentMethod
{
    public class PaymentMethodEditDto
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
