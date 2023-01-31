using System.ComponentModel.DataAnnotations;

namespace Playin.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public ICollection<GameComment> GamesComments { get; set; } 
    }
}
