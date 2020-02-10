using System.Threading.Tasks;
using SmartParkingPermit.Core.Models;

namespace SmartParkingPermit.Core.Interfaces
{
    /// <summary>
    /// Parking Permit Service Contract
    /// </summary>
    public interface IParkingPermitServiceBAL
    {
        Task<bool> InsertParkingPermitDetails(ParkingPermitResquestModel parkingPermitResquestModel);
    }
}
