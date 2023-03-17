using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string SecondName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string Username { get; set; } = default!;

    }
}
