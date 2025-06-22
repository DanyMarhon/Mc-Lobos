using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Locality
{
    public class LocalityListVm
    {
        public int LocalityId { get; set; }
        [DisplayName("Locality")]
        public string LocalityName { get; set; } = null!;
        public bool Delivery { get; set; }
    }
}
