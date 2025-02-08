using System.ComponentModel.DataAnnotations;

namespace konyvtar.Models
{
    public class Book
    {
        [Required(ErrorMessage = "A cím megadása kötelező")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A cím 2 és 100 karakter között lehet")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A szerző megadása kötelező")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "A szerző neve 2 és 50 karakter között lehet")]
        public string Author { get; set; }

        [Range(1800, 2025, ErrorMessage = "A kiadás éve 1800 és 2025 között lehet")]
        public int PublicationYear { get; set; }
    }
}