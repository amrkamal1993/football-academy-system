using System;
using System.ComponentModel.DataAnnotations;

namespace FootballAcademyAPI.Models
{
    public class Subscription(string notes)
    {
        public int SubscriptionId { get; init; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; } = notes;

        // Navigation
        public Player? Player { get; init; } // read-only
    }
}