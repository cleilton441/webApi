using DevEvents.API.Entities;

namespace DevEvents.API.Persistence
{
    public class EventsDbContext
    {
        public EventsDbContext()
        {
            Events = new List<Event>();
        }
        public List<Event> Events { get; set; }
    }
}