using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Model
{
    public class PartsCompatible
    {
        public string PartNumber { get; set; }
        public string PartId { get; set; }
        public string PartCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Parts> CompatibleParts { get; set; }
    }
}
