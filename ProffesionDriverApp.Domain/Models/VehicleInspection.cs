﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfessionDriverApp.Domain.Models
{
    public class VehicleInspection
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleInspectionId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
