using System;
using System.Collections.Generic;

namespace SmartParkingPermit.Core.Models.DB
{
    public partial class ParkingPermit
    {
        public long Id { get; set; }
        public string LicensePlate { get; set; }
        public string CarParkingId { get; set; }
        public string Description { get; set; }
        public string EntityName { get; set; }
        public string Reason { get; set; }
        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        public string ApprovedBy { get; set; }
    }
}
