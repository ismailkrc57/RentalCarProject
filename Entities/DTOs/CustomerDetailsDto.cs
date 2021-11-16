using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailsDto : IDto
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

    }
}
