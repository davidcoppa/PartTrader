using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Model
{
    public class WorkOrder
    {
        public List<WorkOrderDetail> WorkOrderDetails { get; set; }
        public DateTime date { get; set; }
    }
}
