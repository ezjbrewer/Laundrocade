using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class MachineType
{
    public int Id { get; set; }
    public string MachineTypeName { get; set; }
    
}

// class to NOT be extended