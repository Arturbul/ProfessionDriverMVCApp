using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Entity
    {
        [Key] //PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId { get; set; }
        public string? EntityName { get; set; }
    }
}
