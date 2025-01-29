using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class MaintenanceRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MachineId { get; set; }
    public DateTime? MaintenanceDate { get; set; }
    public DateTime RequestCreationDate { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public bool IsRequestFulfilled { get; set; }
    public UserProfile User { get; set; }
    public Machine Machine { get; set; }
    
}