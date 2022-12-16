using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Model{
    public class Game{
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public ICollection<Tag> Tags { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<User> LikedBy { get; set; } = null!;
        
        public float AvgRating { get; set; }
        //tva kakvo e
        public Game(){

        }
    }
}
