using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EventMananger.Models
{
    public class EventTypeViewModel
    {
        public List<Event>? Events { get; set; }
        public SelectList? Types { get; set; }
        public string? EventTypes { get; set; }
        public string? SearchString { get; set; }
    }
}
