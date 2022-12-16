using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Model{
    public class User : IdentityUser{
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> LikedGames { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
        
        public User(string userName) : base(userName){

        }
    }
}


