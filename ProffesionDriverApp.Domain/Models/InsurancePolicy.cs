﻿using ProfessionDriverApp.Domain.Interfaces;

namespace ProfessionDriverApp.Domain.Models
{
    public class InsurancePolicy : EntityBase, ICompanyScope
    {
        public int InsurancePolicyId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public string? Owner { get; set; }
        public string? AccountNumber { get; set; }
        public int CompanyId { get; set; }
        public override object Key => InsurancePolicyId;
    }
}
