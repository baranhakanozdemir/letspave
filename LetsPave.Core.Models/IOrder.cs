using System.ComponentModel.DataAnnotations;

namespace LetsPave.Core.Models
{
    public interface IOrder: ICoreDomainModel<Guid>
    {
        string OrderId { get; set; }
        DateTime OrderDate { get; set; }
        DateTime ShipDate { get; set; }
        ShipModes ShipMode { get; set; }

    }

    public class Order : CoreDomainModel<Guid>, IOrder
    {
        public required string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public ShipModes ShipMode { get; set; }
    }

    public enum ShipModes
    {
        [Display(Name = "First Class")]
        FirstClass,

        [Display(Name = "Second Class")]
        SecondClass,

        [Display(Name = "Standard Class")]
        StandardClass,

        [Display(Name = "Same Day")]
        SameDay
    }
}
