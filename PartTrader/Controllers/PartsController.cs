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
    public class PartsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DataAccess dataAccess;

        public PartsController(IMapper mapper, DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.mapper = mapper;
        }

        
        /// <summary>
        /// get the compatible parts based in a item to find.
        /// first check if the part exist on the Parts Trader database,
        /// and then check for the compatible parts related
        /// </summary>
        /// <param name="partToFind"></param>
        /// <returns>the Part and with a collection of the compatible parts, 
        /// if the part doesn't have compatible parts, retunr an empty collection</returns>
        [HttpPost]
        [Route("FindCompatibleParts")]
        public async Task<ActionResult> FindCompatibleParts([FromBody]PartsFilterDTO partToFind)
        {
            try
            {
                PartsFilter filter = mapper.Map<PartsFilter>(partToFind);

                List<Parts> partsToSearch = dataAccess.GetFilteredCatalogue(filter);
                if (partsToSearch.Count == 0)
                {
                    return BadRequest("Unable to obtain any value with the PartNumber" );
                }

                List<PartsCompatible> compatibleParts = dataAccess.FindCompatibleParts(partsToSearch);

                return Ok(compatibleParts);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

