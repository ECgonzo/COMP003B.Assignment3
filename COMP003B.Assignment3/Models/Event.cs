
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class Event
    {
        // TODO: other c# built-in data types https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
        // TODO: data in square brackets are data annotations
        [Required]
        // TODO: below is an example of a property
        public string Location { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Event Name")]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

    }
}
