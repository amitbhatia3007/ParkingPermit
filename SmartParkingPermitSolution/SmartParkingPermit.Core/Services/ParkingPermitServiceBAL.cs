using System.Threading.Tasks;
using AutoMapper;
using SmartParkingPermit.Core.Interfaces;
using SmartParkingPermit.Core.Models;

namespace SmartParkingPermit.Core.Services
{
    public class ParkingPermitServiceBAL : IParkingPermitServiceBAL
    {
        private readonly IParkingPermitServiceDAL _parkingPermitServiceDAL;
        public ParkingPermitServiceBAL(IParkingPermitServiceDAL parkingPermitServiceDAL)
        {
            _parkingPermitServiceDAL = parkingPermitServiceDAL;
        }
        public async Task<bool> InsertParkingPermitDetails(ParkingPermitResquestModel parkingPermitResquestModel)
        {
            var output = await _parkingPermitServiceDAL.InsertParkingPermitDetails(parkingPermitResquestModel);
            return output > 0;
        }
    }
}
