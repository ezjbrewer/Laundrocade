using Laundrocade.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laundrocade.Data;

public class LaundrocadeDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<MachineType> MachineTypes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    public LaundrocadeDbContext(
        DbContextOptions<LaundrocadeDbContext> context,
        IConfiguration config
    )
        : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    Name = "Admin",
                    NormalizedName = "admin"
                }
            );

        modelBuilder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                        null,
                        _configuration["AdminPassword"]
                    )
                }
            );

        modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                }
            );
        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    UserName = "Lord Admin",
                    Email = "admina@strator.comx"
                }
            );

        modelBuilder
            .Entity<MachineType>()
            .HasData(
                [
                    new MachineType { Id = 1, MachineTypeName = "Washer" },
                    new MachineType { Id = 2, MachineTypeName = "Dryer" },
                    new MachineType { Id = 3, MachineTypeName = "Vending Machine" }
                ]
            );

        modelBuilder
            .Entity<Location>()
            .HasData(
                [
                    new Location
                    {
                        Id = 1,
                        StreetNumber = 242,
                        StreetName = "Pottleworth Street",
                        Suite = "A",
                        CityName = "Gretna",
                        StateId = 27,
                        ZipCode = "68028"
                    },
                    new Location
                    {
                        Id = 2,
                        StreetNumber = 555,
                        StreetName = "Maple Avenue",
                        Suite = null,
                        CityName = "Omaha",
                        StateId = 27,
                        ZipCode = "68114"
                    },
                    new Location
                    {
                        Id = 3,
                        StreetNumber = 1201,
                        StreetName = "Farnam Street",
                        Suite = "Suite 300",
                        CityName = "Lincoln",
                        StateId = 27,
                        ZipCode = "68508"
                    },
                    new Location
                    {
                        Id = 4,
                        StreetNumber = 789,
                        StreetName = "Prairie Lane",
                        Suite = null,
                        CityName = "Fremont",
                        StateId = 27,
                        ZipCode = "68025"
                    },
                    new Location
                    {
                        Id = 5,
                        StreetNumber = 301,
                        StreetName = "Highland Drive",
                        Suite = "B",
                        CityName = "Bellevue",
                        StateId = 27,
                        ZipCode = "68005"
                    }
                ]
            );

        modelBuilder
            .Entity<Machine>()
            .HasData(
                new Machine
                {
                    Id = 1,
                    MachineTypeId = 1,
                    LocationId = 1,
                    Name = "Main Washer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-2),
                    TotalUsageTimeMinutes = 45m,
                    CostPerUsage = 2.50m,
                    OperatingCost = 120.00m,
                    IsOperational = true,
                    Model = "AquaFlow X1",
                    Maker = "Atlantis Tech",
                    SerialNumber = "AT-W12345"
                },
                new Machine
                {
                    Id = 2,
                    MachineTypeId = 1,
                    LocationId = 1,
                    Name = "Main Washer 2",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-1),
                    TotalUsageTimeMinutes = 45m,
                    CostPerUsage = 2.50m,
                    OperatingCost = 120.00m,
                    IsOperational = true,
                    Model = "AquaFlow X2",
                    Maker = "Atlantis Tech",
                    SerialNumber = "AT-W12346"
                },
                new Machine
                {
                    Id = 3,
                    MachineTypeId = 2,
                    LocationId = 1,
                    Name = "Main Dryer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-3),
                    TotalUsageTimeMinutes = 60m,
                    CostPerUsage = 2.00m,
                    OperatingCost = 150.00m,
                    IsOperational = true,
                    Model = "HeatWave 2000",
                    Maker = "Wayne Industries",
                    SerialNumber = "WI-D98765"
                },
                new Machine
                {
                    Id = 4,
                    MachineTypeId = 2,
                    LocationId = 2,
                    Name = "Downtown Dryer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-4),
                    TotalUsageTimeMinutes = 60m,
                    CostPerUsage = 2.00m,
                    OperatingCost = 150.00m,
                    IsOperational = true,
                    Model = "HeatWave 2100",
                    Maker = "Wayne Industries",
                    SerialNumber = "WI-D98766"
                },
                new Machine
                {
                    Id = 5,
                    MachineTypeId = 1,
                    LocationId = 2,
                    Name = "Downtown Washer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-2),
                    TotalUsageTimeMinutes = 45m,
                    CostPerUsage = 2.75m,
                    OperatingCost = 130.00m,
                    IsOperational = true,
                    Model = "TideMaster 3000",
                    Maker = "LexCorp Appliances",
                    SerialNumber = "LC-W11111"
                },
                new Machine
                {
                    Id = 6,
                    MachineTypeId = 3,
                    LocationId = 2,
                    Name = "Snack Vending 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-1),
                    TotalUsageTimeMinutes = null,
                    CostPerUsage = 1.50m,
                    OperatingCost = 1040.00m,
                    IsOperational = true,
                    Model = "SnackBot S1",
                    Maker = "Kord Enterprises",
                    SerialNumber = "KE-V44444"
                },
                new Machine
                {
                    Id = 7,
                    MachineTypeId = 3,
                    LocationId = 3,
                    Name = "Beverage Vending 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-1),
                    TotalUsageTimeMinutes = null,
                    CostPerUsage = 1.75m,
                    OperatingCost = 1040.00m,
                    IsOperational = true,
                    Model = "DrinkMaster D2",
                    Maker = "Kord Enterprises",
                    SerialNumber = "KE-V55555"
                },
                new Machine
                {
                    Id = 8,
                    MachineTypeId = 2,
                    LocationId = 3,
                    Name = "Fremont Dryer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-2),
                    TotalUsageTimeMinutes = 50m,
                    CostPerUsage = 1.75m,
                    OperatingCost = 140.00m,
                    IsOperational = true,
                    Model = "HeatWave 2200",
                    Maker = "Wayne Industries",
                    SerialNumber = "WI-D98767"
                },
                new Machine
                {
                    Id = 9,
                    MachineTypeId = 1,
                    LocationId = 4,
                    Name = "Bellevue Washer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-3),
                    TotalUsageTimeMinutes = 40m,
                    CostPerUsage = 3.00m,
                    OperatingCost = 110.00m,
                    IsOperational = true,
                    Model = "WaveBlaster 4000",
                    Maker = "Queen Consolidated",
                    SerialNumber = "QC-W22222"
                },
                new Machine
                {
                    Id = 10,
                    MachineTypeId = 2,
                    LocationId = 4,
                    Name = "Bellevue Dryer 1",
                    TotalLifetimeRevenue = 0m,
                    LastMaintenanceDate = DateTime.Now.AddMonths(-3),
                    TotalUsageTimeMinutes = 55m,
                    CostPerUsage = 2.50m,
                    OperatingCost = 130.00m,
                    IsOperational = true,
                    Model = "HeatPro X",
                    Maker = "LexCorp Appliances",
                    SerialNumber = "LC-D33333"
                }
            );

        modelBuilder
            .Entity<MaintenanceRequest>()
            .HasData(
                new MaintenanceRequest
                {
                    Id = 1,
                    UserId = 1,
                    MachineId = 3,
                    MaintenanceDate = DateTime.Now.AddDays(-7),
                    RequestCreationDate = DateTime.Now.AddDays(-10),
                    Description = "Replaced heating element and cleaned lint trap.",
                    Cost = 75.00m,
                    IsRequestFulfilled = true
                },
                new MaintenanceRequest
                {
                    Id = 2,
                    UserId = 1,
                    MachineId = 6,
                    MaintenanceDate = DateTime.Now.AddDays(-3),
                    RequestCreationDate = DateTime.Now.AddDays(-5),
                    Description = "Restocked vending machine and calibrated coin sensor.",
                    Cost = 50.00m,
                    IsRequestFulfilled = true
                },
                new MaintenanceRequest
                {
                    Id = 3,
                    UserId = 1,
                    MachineId = 9,
                    MaintenanceDate = null,
                    RequestCreationDate = DateTime.Now,
                    Description = "Reported unusual noise during spin cycle. Pending inspection.",
                    Cost = 0.00m,
                    IsRequestFulfilled = false
                }
            );

        modelBuilder
            .Entity<AuditLog>()
            .HasData(
                new AuditLog
                {
                    Id = 1,
                    MachineId = 3,
                    UserProfileId = 1,
                    ChangeType = "Location Change",
                    OldValue = "Location: Bellevue",
                    NewValue = "Location: Gretna",
                    AuditCreationDate = DateTime.Now.AddDays(-15)
                },
                new AuditLog
                {
                    Id = 2,
                    MachineId = 1,
                    UserProfileId = 1,
                    ChangeType = "Glass Cracked",
                    OldValue = "Washer door glass shattered due to impact.",
                    NewValue = "Replaced washer door glass with reinforced material.",
                    AuditCreationDate = DateTime.Now.AddDays(-10)
                },
                new AuditLog
                {
                    Id = 3,
                    MachineId = 6,
                    UserProfileId = 1,
                    ChangeType = "Coin Jam",
                    OldValue = "Coin slot blocked, unable to accept payments.",
                    NewValue = "Removed blockage and cleaned coin sensor.",
                    AuditCreationDate = DateTime.Now.AddDays(-5)
                }
            );

            modelBuilder
                .Entity<State>()
                .HasData(
                    new State {Id = 1, StateName = "Alabama", StateAbbreviation = "AL"},
                    new State {Id = 2, StateName = "Alaska", StateAbbreviation = "AK"},
                    new State {Id = 3, StateName = "Arizona", StateAbbreviation = "AZ"},
                    new State {Id = 4, StateName = "Arkansas", StateAbbreviation = "AR"},
                    new State {Id = 5, StateName = "California", StateAbbreviation = "CA"},
                    new State {Id = 6, StateName = "Colorado", StateAbbreviation = "CO"},
                    new State {Id = 7, StateName = "Connecticut", StateAbbreviation = "CT"},
                    new State {Id = 8, StateName = "Delaware", StateAbbreviation = "DE"},
                    new State {Id = 9, StateName = "Florida", StateAbbreviation = "FL"},
                    new State {Id = 10, StateName = "Georgia", StateAbbreviation = "GA"},
                    new State {Id = 11, StateName = "Hawaii", StateAbbreviation = "HI"},
                    new State {Id = 12, StateName = "Idaho", StateAbbreviation = "ID"},
                    new State {Id = 13, StateName = "Illinois", StateAbbreviation = "IL"},
                    new State {Id = 14, StateName = "Indiana", StateAbbreviation = "IN"},
                    new State {Id = 15, StateName = "Iowa", StateAbbreviation = "IA"},
                    new State {Id = 16, StateName = "Kansas", StateAbbreviation = "KS"},
                    new State {Id = 17, StateName = "Kentucky", StateAbbreviation = "KY"},
                    new State {Id = 18, StateName = "Louisiana", StateAbbreviation = "LA"},
                    new State {Id = 19, StateName = "Maine", StateAbbreviation = "ME"},
                    new State {Id = 20, StateName = "Maryland", StateAbbreviation = "MD"},
                    new State {Id = 21, StateName = "Massachusetts", StateAbbreviation = "MA"},
                    new State {Id = 22, StateName = "Michigan", StateAbbreviation = "MI"},
                    new State {Id = 23, StateName = "Minnesota", StateAbbreviation = "MN"},
                    new State {Id = 24, StateName = "Mississippi", StateAbbreviation = "MS"},
                    new State {Id = 25, StateName = "Missouri", StateAbbreviation = "MO"},
                    new State {Id = 26, StateName = "Montana", StateAbbreviation = "MT"},
                    new State {Id = 27, StateName = "Nebraska", StateAbbreviation = "NE"},
                    new State {Id = 28, StateName = "Nevada", StateAbbreviation = "NV"},
                    new State {Id = 29, StateName = "New Hampshire", StateAbbreviation = "NH"},
                    new State {Id = 30, StateName = "New Jersey", StateAbbreviation = "NJ"},
                    new State {Id = 31, StateName = "New Mexico", StateAbbreviation = "NM"},
                    new State {Id = 32, StateName = "New York", StateAbbreviation = "NY"},
                    new State {Id = 33, StateName = "North Carolina", StateAbbreviation = "NC"},
                    new State {Id = 34, StateName = "North Dakota", StateAbbreviation = "ND"},
                    new State {Id = 35, StateName = "Ohio", StateAbbreviation = "OH"},
                    new State {Id = 36, StateName = "Oklahoma", StateAbbreviation = "OK"},
                    new State {Id = 37, StateName = "Oregon", StateAbbreviation = "OR"},
                    new State {Id = 38, StateName = "Pennsylvania", StateAbbreviation = "PA"},
                    new State {Id = 39, StateName = "Rhode Island", StateAbbreviation = "RI"},
                    new State {Id = 40, StateName = "South Carolina", StateAbbreviation = "SC"},
                    new State {Id = 41, StateName = "South Dakota", StateAbbreviation = "SD"},
                    new State {Id = 42, StateName = "Tennessee", StateAbbreviation = "TN"},
                    new State {Id = 43, StateName = "Texas", StateAbbreviation = "TX"},
                    new State {Id = 44, StateName = "Utah", StateAbbreviation = "UT"},
                    new State {Id = 45, StateName = "Vermont", StateAbbreviation = "VT"},
                    new State {Id = 46, StateName = "Virginia", StateAbbreviation = "VA"},
                    new State {Id = 47, StateName = "Washington", StateAbbreviation = "WA"},
                    new State {Id = 48, StateName = "West Virginia", StateAbbreviation = "WV"},
                    new State {Id = 49, StateName = "Wisconsin", StateAbbreviation = "WI"},
                    new State {Id = 50, StateName = "Wyoming", StateAbbreviation = "WY"}
                );

    }
}
