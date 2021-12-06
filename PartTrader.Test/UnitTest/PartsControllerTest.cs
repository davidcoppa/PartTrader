using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartTrader.API.Controllers;
using PartTrader.API.DTOs;
using PartTrader.API.Helpers.AutoMapper;
using PartTrader.API.Mock;
using System.Threading.Tasks;

namespace PartTrader.Test.UnitTest
{



    [TestClass]

    public class PartsControllerTest
    {
        private static IMapper _mapper;
        private static DataAccess dataAccess;

        public PartsControllerTest()
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
        public async Task PartsControllerNOFindCompatiblePartsTest()
        {
            //prep
            var partController = new PartsController(_mapper, dataAccess);
            var value = new PartsFilterDTO
            {
                Description = "",
                PartCode = "adsfasfasdfa2s",
                PartId = "9876"
            };

            //eject
            ActionResult result = await partController.FindCompatibleParts(value);

            var contentResult = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            Assert.AreEqual("Unable to obtain any value with the PartNumber", contentResult.Value.ToString());

        }
    }
}
