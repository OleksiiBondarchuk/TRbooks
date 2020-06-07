using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TRbooks.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public BookGenreDto BookGenre { get; set; }

        [Required]
        public int BookGenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public DateTime? AddedDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number in stock must be between {1} and {2}")]
        public int NumberInStock { get; set; }
    }
}