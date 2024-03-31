using Domain.Models.DTO;
using Newtonsoft.Json;
using System;

namespace ProfessionDriver.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public int EntityId { get; set; }
        public EntityDTO? Entity { get; set; }

        public static explicit operator EmployeeViewModel?(EmployeeDTO? obj)
          => JsonConvert.DeserializeObject<EmployeeViewModel?>(JsonConvert.SerializeObject(obj));

        public static explicit operator EmployeeDTO?(EmployeeViewModel? obj)
          => JsonConvert.DeserializeObject<EmployeeDTO?>(JsonConvert.SerializeObject(obj));
    }
}
