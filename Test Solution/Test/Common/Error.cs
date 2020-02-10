using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartParkingPermit.Core.Common
{
    public class Error
    {
        [IgnoreDataMember]
        public List<string> Errors { get; set; }
        [IgnoreDataMember]
        public bool Flag { get; set; }
    }
}
