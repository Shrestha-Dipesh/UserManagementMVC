using System.ComponentModel.DataAnnotations;

namespace UserManagementWebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
