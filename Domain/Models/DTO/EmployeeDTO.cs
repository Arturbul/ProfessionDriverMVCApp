using Newtonsoft.Json;

namespace Domain.Models.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int EntityId { get; set; }

        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }

        public static explicit operator Employee?(EmployeeDTO? obj)
            => JsonConvert.DeserializeObject<Employee?>(JsonConvert.SerializeObject(obj));

        public static explicit operator EmployeeDTO?(Employee? obj)
            => JsonConvert.DeserializeObject<EmployeeDTO?>(JsonConvert.SerializeObject(obj));
    }
}
