﻿using ProfessionDriverApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Domain.Models
{
    public class Vehicle : EntityBase, ICompanyScope
    {
        public int VehicleId { get; set; }

        [MaxLength(12)]
        public string RegistrationNumber { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? VehicleInsuranceId { get; set; }
        public int? VehicleInspectionId { get; set; }
        public VehicleInsurance? VehicleInsurance { get; set; }
        public VehicleInspection? VehicleInspection { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public override object Key => VehicleId;
    }
}
