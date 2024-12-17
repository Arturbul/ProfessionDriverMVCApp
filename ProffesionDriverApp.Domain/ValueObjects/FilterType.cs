using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProfessionDriverApp.Domain.ValueObjects
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // Konwersja JSON między string a enum
    public enum FilterType
    {
        [EnumMember(Value = "last7Days")]
        Last7Days,

        [EnumMember(Value = "currentMonth")]
        CurrentMonth,

        [EnumMember(Value = "currentYear")]
        CurrentYear,

        [EnumMember(Value = "custom")]
        Custom
    }
}
