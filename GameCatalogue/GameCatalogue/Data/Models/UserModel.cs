using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Model{
    public class User : IdentityUser{
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime create_at { get; set; }


        public User(string userName) : base(userName){

        }
    }
}


