namespace ProfessionDriverApp.Application.DTOs
{
    public class DriverWorkLogDTO
    {
        public Guid? DriverWorkLogId { get; set; }
        public TransportUnitDTO? TransportUnit { get; set; }
        public DriverWorkLogEntryDTO? StartEntry { get; set; }
        public DriverWorkLogEntryDTO? EndEntry { get; set; }
    }
}
