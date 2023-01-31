using Playin.Models;
using System.Collections.Generic;

namespace Playin.ViewModels
{
    public class GameCommentViewModel
    {
        public string Title { get; set; }
        public List<GameComment> ListOfComments { get; set; }
        public string Comment { get; set; }
        public int GamesId { get; set; }
        public int Rating { get; set; }

    }
}
