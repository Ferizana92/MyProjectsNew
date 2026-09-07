using System.ComponentModel.DataAnnotations;

namespace MyProjectsNew.Entities
{
    public class CustomerPersonnelNames
    {
        [Key]
        public int Id { get; set; } 
        public int Code { get; set; } 
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
