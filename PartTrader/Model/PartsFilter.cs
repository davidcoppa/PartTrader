using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Model
{
    public class PartsFilter
    {
        public string PartId { get; set; }
        public string PartCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }

        public double Price { get; set; }
    }
}
