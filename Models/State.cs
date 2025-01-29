using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models;

public class State
{
    public int Id { get; set; }
    public string StateName { get; set; }
    public string StateAbbreviation { get; set; }
}

// class to NOT be extended