using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCatalogue.Model{
    public class Review{
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int GameId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int RatingScore { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public Review(){

        }
    }
}
