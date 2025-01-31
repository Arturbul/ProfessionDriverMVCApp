﻿namespace ProfessionDriverApp.Domain.Models
{
    public abstract class EntityBase
    {
        public DateTime? Created { get; set; }
        public string Creator { get; set; } = null!;
        public DateTime? Modified { get; set; }
        public string? Modifier { get; set; }
        public bool IsDeleted { get; set; } = false;
        public abstract object Key { get; }
    }
}