using System;
using System.ComponentModel.DataAnnotations;

namespace BookDonorsAPI.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tittle { get; set; } = string.Empty; // Default value to avoid nullability warning

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty; // Default value to avoid nullability warning

        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty; // Default value to avoid nullability warning

        [Required]
        [Range(1450, 2100, ErrorMessage = "Please enter a valid year.")]
        public int YearPublished { get; set; } // No need for default, DateTime is non-nullable

    }
}