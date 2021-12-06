using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartTrader.API.DTOs;
using PartTrader.API.Mock;
using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private DataAccess dataAccess;

        public WorkOrderController(IMapper mapper, DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.mapper = mapper;
        }



        /// <summary>
        /// Creates a work order with all the details of the order, adding the current date
        /// the main idea is to get all the data as repairers, total amount, quantity... and create the order.
        /// </summary>
        /// <param name="workOrderItems"></param>
        /// <returns>returns a work order with all the information</returns>
        [HttpPost]
        [Route("CreateWorkOrder")]
        public async Task<ActionResult> CreateWorkOrder([FromBody] List<WorkOrderDTO> workOrderItems)
        {
            try
            {
                WorkOrder workOrder = new WorkOrder
                {
                    date = DateTime.Now,
                    WorkOrderDetails = new List<WorkOrderDetail>()
                };
                if (workOrderItems.Count==0)
                {
                    return BadRequest("Work order is empty");
                }

                foreach (WorkOrderDTO item in workOrderItems)
                {
                    Parts order = mapper.Map<Parts>(item);

                    WorkOrderDetail wod = new WorkOrderDetail
                    {
                        part = order
                    };

                    workOrder.WorkOrderDetails.Add(wod);
                }


                dataAccess.AddOrder(workOrder);

                return Ok(workOrder);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
