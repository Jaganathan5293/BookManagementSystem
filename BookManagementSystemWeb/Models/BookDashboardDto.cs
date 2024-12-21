namespace BookManagementSystem.Web.Models;

public class BookDashboardDto
{
    public int TotalBooks { get; set; }
    public decimal AverageRating { get; set; }
    public Dictionary<string, int> BooksByGenre { get; set; } = new();
}
