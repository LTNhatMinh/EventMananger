using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMananger.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string? EventImage { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventType { get; set; }

        [Required]
        [StringLength(60)]
        public string EventOrganizer { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public string? EventLocation { get; set; }

        [Required]
        public string EventStatus { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal EventFunding { get; set; }

        public string? EventDescription { get; set; }

    }
}
