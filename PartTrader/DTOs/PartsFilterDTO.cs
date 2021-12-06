using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.DTOs
{
    public class PartsFilterDTO
    {
        public string PartId { get; set; }
        public string PartCode { get; set; }
        
        public string Description { get; set; }

    }
}
