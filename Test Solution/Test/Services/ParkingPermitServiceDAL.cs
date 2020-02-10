using System;
using System.Threading.Tasks;
using AutoMapper;
using SmartParkingPermit.Core.Interfaces;
using SmartParkingPermit.Core.Models;
using SmartParkingPermit.Core.Models.DB;

namespace SmartParkingPermit.Core.Services
{
    public class ParkingPermitServiceDAL : IParkingPermitServiceDAL
    {
        private readonly ParkingPermitContext _parkingPermitContext;
        private readonly IMapper _mapper;

        public ParkingPermitServiceDAL(ParkingPermitContext parkingPermitContext, IMapper mapper)
        {
            _parkingPermitContext = parkingPermitContext;
            _mapper = mapper;
        }
        public Task<int> InsertParkingPermitDetails(ParkingPermitResquestModel parkingPermitResquestModel)
        {
            var parkingPermitobj = new ParkingPermit();
            parkingPermitobj = _mapper.Map<ParkingPermit>(parkingPermitResquestModel);

            _parkingPermitContext.ParkingPermit.Add(parkingPermitobj);
            return _parkingPermitContext.SaveChangesAsync();
        }
    }
}
