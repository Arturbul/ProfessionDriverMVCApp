using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Application.Requests.Create
{
    public class CreateWorkLogEntryRequest
    {
        public string? Brand { get; set; }
        [StringLength(12)]
        public string RegistrationNumber { get; set; } = null!;

        public string? TrailerBrand { get; set; }
        [StringLength(12)]
        public string? RegistrationNumberTrailer { get; set; }
        [Required]
        public DateTime LogTime { get; set; }
        public string? Place { get; set; }
        public float? Mileage { get; set; }
        public string? DriverUserName { get; set; } //if not attached, get userName form JWT
    }
}
