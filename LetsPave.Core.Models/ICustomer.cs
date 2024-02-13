using System.ComponentModel.DataAnnotations;

namespace LetsPave.Core.Models
{
    public interface ICustomer:ICoreDomainModel<Guid>
    {
        string CustomerId { get; set; }
        string CustomerName { get; set; }
        string Country { get; set; }

        string State { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string PostalCode { get; set; }
        public CustomerSegments Segment { get; set; }

    }

    public class Customer : CoreDomainModel<Guid>, ICustomer
    {
        public required string CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public required string Country { get; set; }
        public required string State { get; set; }

        public required string City { get; set; }
        public required string Region { get; set; }
        public required string PostalCode { get; set; }
        public CustomerSegments Segment { get; set; }
    }

    public enum CustomerSegments
    {
        [Display(Name = "Consumer")]
        Consumer,

        [Display(Name = "Home Office")]
        HomeOffice,

        [Display(Name = "Corporate")]
        Corporate
    }
}
