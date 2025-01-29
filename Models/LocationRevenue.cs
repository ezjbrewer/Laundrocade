using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class LocationRevenue
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public DateTime RevenueStartDay { get; set; }
    public DateTime RevenueEndDay { get; set; }
    public decimal TotalRevenue { get; set; }
    public string? Notes { get; set; }
    public Location Location { get; set; }
}

// class to be extended