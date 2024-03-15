using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AEMDemo
{
    public class Key
    {
        public static string? authKey;
    }

    public class LoginRequest
    {
        [Required]
        [MinLength(5,ErrorMessage = "Username must be more than 5 characters")]
        public string? username { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Password must be more than 5 characters")]
        public string? password { get; set; }
    }

    public class ErrorDto
    {
        public string? message { get; set; }
        public string? stackTrace { get; set; }
        public string? innerException { get; set; }
        public string? columnName { get; set; }
        public string? columnValue { get; set; }
    }

    public class ChartDashboardDto
    {
        public string? name { get; set; }
        public double? value { get; set; }
    }

    public class DashboardDto
    {
        public bool success { get; set; }
        public List<ChartDashboardDto>? chartDonut { get; set; }
        public List<ChartDashboardDto>? chartBar { get; set; }
        public List<ChartDashboardDto>? tableUsers { get; set; }
    }

    public class TableUserDto
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? username { get; set; }
    }

    public class WellDto
    {
        public int id { get; set; }
        public int platformId { get; set; }
        public string? uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

    }

    public class PlatformDto
    {
        public int id { get; set; }
        public string? uniqueName { get; set; } 
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public List<WellDto>? well { get; set; }  

    }

    public class WellDummyDto
    {
        public int id { get; set; }
        public int platformId { get; set; }
        public string? uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime? lastUpdate { get; set; }

    }

    public class PlatformDummyDto
    {
        public int id { get; set; }
        public string? uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public DateTime? lastUpdate { get; set; }
        public List<WellDummyDto>? well { get; set; }

    }
}
