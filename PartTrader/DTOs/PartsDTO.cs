using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.DTOs
{
    public class PartsDTO
    {

        public string PartId { get; set; }
        public string PartCode { get; set; }
        public string Description { get; set; }
        public List<PartsDTO> CompatibleParts { get; set; }

        public double Price { get; set; }
    }
}
