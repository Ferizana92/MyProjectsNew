using System.ComponentModel.DataAnnotations;

namespace MyProjectsNew.Entities
{
    public class CustomerName
    {

        [Key]
        public int Code { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
