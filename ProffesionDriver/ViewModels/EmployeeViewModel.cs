﻿using Domain.Models.DTO;
using System;

namespace ProfessionDriverMVC.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public EntityDTO? EntityDTO { get; set; }
    }
}
