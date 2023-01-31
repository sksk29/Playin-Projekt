

namespace Playin.Models
{
    public class GameComment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime PublishedDate { get; set; }
        public int GamesId { get; set; }
        public Game Games { get; set; }
        public int Rating { get; set; }
    }
}