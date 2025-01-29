using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class Machine
{
    public int Id { get; set; }
    public int MachineTypeId { get; set; }
    public int LocationId { get; set; }
    public string Name { get; set; }
    public decimal TotalLifetimeRevenue { get; set; }
    public DateTime? LastMaintenanceDate { get; set; }
    public decimal? TotalUsageTimeMinutes { get; set; }
    public decimal CostPerUsage { get; set;}
    public decimal OperatingCost { get; set; }
    public bool IsOperational { get; set; }
    public string Model { get; set; }
    public string Maker { get; set; }
    public string SerialNumber { get; set; }
    public MachineType MachineType { get; set; }
    public Location Location { get; set; }
}

// class to be extended