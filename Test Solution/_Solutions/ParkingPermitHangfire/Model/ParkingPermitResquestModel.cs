namespace ParkingPermitHangfire.Model
{
    public class ParkingPermitResquestModel
    {
        public string LicensePlate { get; set; }

        private string _CarParkingId;

        public string CarParkingId
        {
            get => _CarParkingId ?? "1";
            set => _CarParkingId = value;

        }
        public string Description { get; set; }
        public string EntityName { get; set; }

        private string _Reason;

        public string Reason
        {
            get => _Reason ?? "Coding Test";
            set => _Reason = value;

        }

        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        private string _ApprovedBy { get; set; }
        public string ApprovedBy
        {
            get => _ApprovedBy ?? "CodingTest@smartercity.com.au";
            set => _ApprovedBy = value;

        }

    }
}
