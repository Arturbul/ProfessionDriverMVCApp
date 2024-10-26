﻿using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Domain.Models
{
    public class Vehicle : EntityBase
    {
        public int VehicleId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public int? EntityId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? VehicleInsuranceId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public Individual? Entity { get; set; }
        public VehicleInsurance? VehicleInsurance { get; set; }
        public VehicleInspection? VehicleInspection { get; set; }
        public override object Key => VehicleId;
    }
}
