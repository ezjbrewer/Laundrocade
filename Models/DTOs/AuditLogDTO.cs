using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

public class AuditLogDTO
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public int UserProfileId { get; set; }
    public string ChangeType { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime AuditCreationDate { get; set; }
    public MachineDTO Machine { get; set; }
    public UserProfileDTO UserProfile { get; set; }
}