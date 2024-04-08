using Domain.Models.DTO;
using Newtonsoft.Json;

namespace Domain.ViewModels
{
    public class EntityViewModel
    {
        public int EntityId { get; set; }
        public string? EntityName { get; set; }

        public static explicit operator EntityViewModel?(EntityDTO? obj)
           => JsonConvert.DeserializeObject<EntityViewModel?>(JsonConvert.SerializeObject(obj));

        public static explicit operator EntityDTO?(EntityViewModel? obj)
          => JsonConvert.DeserializeObject<EntityDTO?>(JsonConvert.SerializeObject(obj));
    }
}
