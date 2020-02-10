using AutoMapper;
using SmartParkingPermit.Core.Models;
using SmartParkingPermit.Core.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParkingPermit.Core.AutoMapperProfile
{
    public class ParkingProfile : Profile
    {
        public ParkingProfile()
        {
            CreateMap<ParkingPermit, ParkingPermitResquestModel>();
            CreateMap<ParkingPermitResquestModel, ParkingPermit>();
        }
    }
}
