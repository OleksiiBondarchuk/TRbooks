using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRbooks.ViewModels;

namespace TRbooks.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Book Genre")]
        public BookGenre BookGenre { get; set; }

        [Required]
        [Display(Name = "Book genre")]
        public int BookGenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public DateTime? AddedDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number in stock must be between {1} and {2}")]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}