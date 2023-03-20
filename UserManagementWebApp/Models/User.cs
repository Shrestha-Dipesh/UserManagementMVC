using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserManagementWebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
