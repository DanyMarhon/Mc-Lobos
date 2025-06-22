namespace TPInvOp.Service.DTOs.Locality
{
    public class LocalityListDto
    {
        public int LocalityId { get; set; }
        public string LocalityName { get; set; } = null!;
        public bool Delivery { get; set; }
    }
}
