using Microsoft.AspNetCore.Identity;

namespace Laundrocade.Models.DTOs;

public class LocationDTO
{
    public int Id { get; set; }
    public int StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string? Suite { get; set; }
    public string CityName { get; set; }
    public int StateId { get; set; }
    public string ZipCode { get; set; }
    public StateDTO State { get; set; }
}