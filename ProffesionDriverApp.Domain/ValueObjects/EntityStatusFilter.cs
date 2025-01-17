namespace ProfessionDriverApp.Domain.ValueObjects
{
    public enum EntityStatusFilter
    {
        Exists,  // Tylko aktywne rekordy
        All,     // Wszystkie rekordy
        Deleted  // Tylko usunięte rekordy
    }
}
