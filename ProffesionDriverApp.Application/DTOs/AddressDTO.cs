﻿namespace ProfessionDriverApp.Application.DTOs
{
    public class AddressDTO
    {
        public string City { get; set; } = "";
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
