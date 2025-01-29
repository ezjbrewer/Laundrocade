using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class MachineRevenue
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public DateTime RevenueStartDay { get; set; }
    public DateTime RevenueEndDay { get; set; }
    public decimal TotalRevenue { get; set; }
    public string? Notes { get; set; }
    public Machine Machine { get; set; }
}

// class to be extended