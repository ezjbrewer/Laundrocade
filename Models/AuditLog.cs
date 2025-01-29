using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class AuditLog
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public int UserProfileId { get; set; }
    public string ChangeType { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime AuditCreationDate { get; set; }
    public Machine Machine { get; set; }
    public UserProfile UserProfile { get; set; }
}

// class to NOT be extended