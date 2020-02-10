using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SmartParkingPermit.Core.Controllers
{
    [Route("SmartParkingPermit/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/home
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "SmartParking Permit Server has been stared" };
        }

    }
}
