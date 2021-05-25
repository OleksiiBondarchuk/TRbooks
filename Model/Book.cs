using System;
using System.Linq;

namespace Library
{
    public class Book
    {
        public static string[] genres = { "Genre1", "Genre2", "Tech" };

        public int Id { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Author { get; }
        public string Description { get; set; }
        public decimal RentalPrice { get; set; }

        public Book(int id, string title, string genre, string author, string description, decimal rentalPrice)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Author = author;
            Description = description;
            RentalPrice = rentalPrice;
        }

        public static bool IsGenre(string query)
        {
            return genres.Contains(query);
        }
    }
}
