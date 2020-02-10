using System.Collections.Generic;

namespace SmartParkingPermit.Core.Common
{
    public class ResponsePackage
    {
        public List<string> Errors { get; set; }

        public object Result { get; set; }
        public ResponsePackage(List<string> errors, object result)
        {
            Errors = errors;
            Result = result;
        }
    }
}