using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Application.Requests.Create
{
    public class CreateWorkLogEntryRequest
    {
        [StringLength(12)]
        public string RegistrationNumber { get; set; } = null!;

        [StringLength(12)]
        public string? RegistrationNumberTrailer { get; set; }
        [Required]
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
        public string? DriverUserName { get; set; } //if not attached, get userName form JWT
    }
}
