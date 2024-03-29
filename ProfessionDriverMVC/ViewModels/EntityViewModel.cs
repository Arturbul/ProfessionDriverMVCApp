﻿using Domain.Models.DTO;
using Newtonsoft.Json;

namespace ProfessionDriverMVC.ViewModels
{
    public class EntityViewModel
    {
        public int EntityId { get; set; }
        public string? EntityName { get; set; }

        public static explicit operator EntityDTO?(EntityViewModel? obj)
             => JsonConvert.DeserializeObject<EntityDTO?>(JsonConvert.SerializeObject(obj));
    }
}
