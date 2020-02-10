using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParkingPermit.Core.Common;
using SmartParkingPermit.Core.Interfaces;
using SmartParkingPermit.Core.ViewModel;

namespace SmartParkingPermit.Core.Controllers
{
    [ApiController]
    [Route("SmartParkingPermit/[controller]/[action]")]
    public class ParkingPermitController : ControllerBase
    {
        private readonly IParkingPermitServiceBAL _parkingPermitServiceBAL;
        public ParkingPermitController(IParkingPermitServiceBAL parkingPermitServiceBAL)
        {
            _parkingPermitServiceBAL = parkingPermitServiceBAL;
        }

        [HttpPost]
        [ActionName("SaveParkingPermit")]
        public async Task<IActionResult> SaveParkingPermit([FromBody] ParkingPermitResquestVM parkingPermitResquestVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Ok(new ResponsePackage(null, false));


                if (parkingPermitResquestVM == null || parkingPermitResquestVM.ParkingPermitResquest == null)
                    return Ok(new ResponsePackage(new List<string> { "Invalid model" }, false));

                var result = await _parkingPermitServiceBAL.InsertParkingPermitDetails(parkingPermitResquestVM.ParkingPermitResquest);
                return Ok(new ResponsePackage(null, result));
            }
            catch (Exception ex)
            {
                return Ok(new ResponsePackage(new List<string> { ex.Message }, null));
            }
        }

    }
}

