using Newtonsoft.Json;

namespace Domain.Models.DTO
{
    public class EntityDTO
    {
        public int EntityId { get; set; }
        public string? EntityName { get; set; }

        public static explicit operator Entity?(EntityDTO? obj)
            => JsonConvert.DeserializeObject<Entity?>(JsonConvert.SerializeObject(obj));
    }
}
