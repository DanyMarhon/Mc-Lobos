using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Locality
{
    public class LocalityEditVm
    {
        public int LocalityId { get; set; }

        [DisplayName("Locality Name")]
        public string LocalityName { get; set; } = null!;

        [DisplayName("Delivery")]
        public bool Delivery { get; set; }
    }
}
