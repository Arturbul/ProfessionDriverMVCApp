using Domain.Models.DTO;
using Newtonsoft.Json;

namespace ProfessionDriver.ViewModels
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDTO? Employee { get; set; }

        //driver work log collection

        public static explicit operator DriverViewModel?(DriverDTO? obj)
         => JsonConvert.DeserializeObject<DriverViewModel?>(JsonConvert.SerializeObject(obj));

        public static explicit operator DriverDTO?(DriverViewModel? obj)
          => JsonConvert.DeserializeObject<DriverDTO?>(JsonConvert.SerializeObject(obj));
    }
}
