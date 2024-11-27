using System;
using System.ComponentModel.DataAnnotations;

namespace BookDonorsAPI.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // Default to avoid nullable warning

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty; // Default to avoid nullable warning

        [Phone]
        [MaxLength(100)] // Matches the database column definition
        public string Phone { get; set; } = string.Empty; // Default to avoid nullable warning

        [MaxLength(100)] // Adjusted max length to match the database
        public string BookTittle { get; set; } = string.Empty; // Default to avoid nullable warning
    }
}