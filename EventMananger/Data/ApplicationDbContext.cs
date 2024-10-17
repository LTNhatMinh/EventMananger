using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventMananger.Models;

namespace EventMananger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventMananger.Models.Event>? Event { get; set; }
        public DbSet<EventMananger.Models.EventParticipant>? EventParticipant { get; set; }
    }
}
