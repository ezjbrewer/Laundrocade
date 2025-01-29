using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

public class MachineRevenueDTO
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public DateTime RevenueStartDay { get; set; }
    public DateTime RevenueEndDay { get; set; }
    public decimal TotalRevenue { get; set; }
    public string? Notes { get; set; }
    public MachineDTO Machine { get; set; }
}