using System.ComponentModel.DataAnnotations;

namespace GameCatalogue.Model
{
    public class Tag{
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;

        public ICollection<Game> Games { get; set; } = null!;

        public Tag(){

        }
    }
}
