namespace TPInvOp.Model.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactPhone { get; set; }
        public string? DeliveryAddress { get; set; }
        public int LocalityID { get; set; }
        public Locality? Locality { get; set; }
    }
}
