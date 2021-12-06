using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartTrader.API.Controllers;
using PartTrader.API.DTOs;
using PartTrader.API.Helpers.AutoMapper;
using PartTrader.API.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PartTrader.Test.UnitTest
{
    [TestClass]

    public class WorkOrderControllerTest
    {
        private static IMapper _mapper;
        private static DataAccess dataAccess;

        public WorkOrderControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            dataAccess = new DataAccess();

        }


        [TestMethod]
        public async Task WorkOrderControllerWorkOrderEmpty()
        {
            //prep
            var partController = new WorkOrderController(_mapper, dataAccess);

            //eject
            ActionResult result = await partController.CreateWorkOrder(new List<WorkOrderDTO>());

            var contentResult = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            Assert.AreEqual("Work order is empty", contentResult.Value.ToString());

        }
    }
}
