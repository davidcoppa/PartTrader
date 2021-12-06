using AutoMapper;
using PartTrader.API.DTOs;
using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Helpers.AutoMapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Parts, PartsDTO>().ReverseMap();
            CreateMap<PartsFilter, PartsFilterDTO>().ReverseMap();
            CreateMap<WorkOrderDTO, Parts>().ReverseMap();

        }
    }
}
