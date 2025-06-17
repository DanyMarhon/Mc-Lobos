using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInvOp.Model.DTOs.Locality
{
    public class LocalityDTO
    {
        public int LocalityId { get; set; }
        public string LocalityName { get; set; } = null!;
        public bool Delivery { get; set; }
    }
}
