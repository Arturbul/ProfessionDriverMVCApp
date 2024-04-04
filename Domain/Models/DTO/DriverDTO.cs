using Newtonsoft.Json;

namespace Domain.Models.DTO
{
    public class DriverDTO
    {
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }
        //driver work log list

        public static explicit operator Driver?(DriverDTO? obj)
            => JsonConvert.DeserializeObject<Driver?>(JsonConvert.SerializeObject(obj));

        public static explicit operator DriverDTO?(Driver? obj)
            => JsonConvert.DeserializeObject<DriverDTO?>(JsonConvert.SerializeObject(obj));
    }
}
