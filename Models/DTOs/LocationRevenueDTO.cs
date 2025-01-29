using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

public class LocationRevenueDTO
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public DateTime RevenueStartDay { get; set; }
    public DateTime RevenueEndDay { get; set; }
    public decimal TotalRevenue { get; set; }
    public string? Notes { get; set; }
    public LocationDTO Location { get; set; }
}