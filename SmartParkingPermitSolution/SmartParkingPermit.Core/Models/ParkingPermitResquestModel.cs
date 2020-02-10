using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkingPermit.Core.Models
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
    public class ParkingPermitResquestModelValidator : AbstractValidator<ParkingPermitResquestModel>
    {
        public ParkingPermitResquestModelValidator()
        {
            RuleFor(x => x.ValidFrom).NotNull();
            RuleFor(x => x.ValidUntil).NotNull();
        }
    }
}