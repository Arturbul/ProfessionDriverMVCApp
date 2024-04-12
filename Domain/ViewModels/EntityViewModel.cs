namespace Domain.ViewModels
{
    public class EntityViewModel
    {
        public int EntityId { get; set; }
        public string? EntityName { get; set; }
        public override string ToString()
        {
            return $"EntityId: {EntityId}, Entity name: {EntityName}";
        }
    }
}
