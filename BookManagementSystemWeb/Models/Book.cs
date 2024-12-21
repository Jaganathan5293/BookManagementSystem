using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.Web.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [Range(1000, 9999)]
    public int PublishedYear { get; set; }

    [Required]
    [Range(0, 10000)]
    public decimal Price { get; set; }

    [Range(0, 100)]
    public decimal DiscountPercentage { get; set; }

    [Range(0, 5)]
    public decimal Rating { get; set; }

    public decimal FinalPrice => Price * (1 - DiscountPercentage / 100);
}
