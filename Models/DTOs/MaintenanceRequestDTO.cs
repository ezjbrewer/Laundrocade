using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

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
    public UserProfileDTO User { get; set; }
    public MachineDTO Machine { get; set; }
    
}