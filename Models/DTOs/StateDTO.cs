using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

public class StateDTO
{
    public int Id { get; set; }
    public string StateName { get; set; }
    public string StateAbbreviation { get; set; }
}