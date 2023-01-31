using System.ComponentModel.DataAnnotations;

namespace Playin.Models
{
    public class Esport
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
    }
}
