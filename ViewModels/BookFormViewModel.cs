using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRbooks.Models;
using System.ComponentModel.DataAnnotations;

namespace TRbooks.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<BookGenre> BookGenres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Book genre")]
        public int? BookGenreId { get; set; }

        [Required]
        [Display(Name = "ReleaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? AddedDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number in stock must be between {1} and {2}")]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        public string Title {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }
        public BookFormViewModel()
        {
            Id = 0;
        }
        public BookFormViewModel(Book book) 
        {
            Id = book.Id;
            Name = book.Name;
            BookGenreId = book.BookGenreId;
            ReleaseDate = book.ReleaseDate;
            AddedDate = book.AddedDate;
            NumberInStock = book.NumberInStock;
        }
    }
}