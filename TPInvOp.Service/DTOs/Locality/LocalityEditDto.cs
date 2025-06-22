using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInvOp.Service.DTOs.Locality
{
    public class LocalityEditDto
    {
        public int LocalityId { get; set; }
        public string LocalityName { get; set; } = null!;
        public bool Delivery { get; set; }
    }
}
