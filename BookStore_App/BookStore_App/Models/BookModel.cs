using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore_App.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength=5)]
        [Required(ErrorMessage ="Please enter the title of your book")]
        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Display(Name ="Total pages")]
        [Required(ErrorMessage = "Please enter the total pages")]
        public int? TotalPages { get; set; }
    }
}
