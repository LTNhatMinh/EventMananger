namespace EventMananger.Models
{
    public class EventParticipant
    {
        public int EventParticipantId { get; set; }
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public string EventParticipantName { get; set; }
        public string? EventParticipantEmail { get; set; }
        public string? EventParticipantPhone { get; set; }
    }
}
