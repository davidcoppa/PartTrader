using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.DTOs
{
    public class PartsCompatibleDTO
    {
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public List<PartsDTO> CompatibleParts { get; set; }
    }
}
