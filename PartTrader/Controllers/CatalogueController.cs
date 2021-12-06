using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartTrader.API.DTOs;
using PartTrader.API.Mock;
using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CatalogueController : ControllerBase
    {

        private readonly IMapper mapper;
        private DataAccess dataAccess;
        public CatalogueController(IMapper mapper,DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.mapper = mapper;
        }


        /// <summary>
        /// returns all the parts from the Data Base
        /// </summary>
        /// <returns>return the full collection of the items in catalogue</returns>
        [HttpGet]
        [Route("GetCatalogueList")]
        public async Task<ActionResult> GetCatalogueList()
        {
            try
            {
                List<Parts> itemList = dataAccess.GetFullCatalogue();

                List<PartsDTO> returnList = mapper.Map<List<PartsDTO>>(itemList);

                return Ok(returnList);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
