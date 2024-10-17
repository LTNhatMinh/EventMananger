using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace EventMananger.Models
{
    public class EventParticipantViewModel
    {
        public List<EventParticipant>? EventParticipants { get; set; }
        public SelectList? Name { get; set; }
        public string? EventNames { get; set; }
        public string? SearchString { get; set; }

    }
}


