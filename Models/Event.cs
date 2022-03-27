using System.ComponentModel.DataAnnotations;

namespace VolgaIT2022App5.Models
{
    public enum EventType { POST, GET}
    public class Event
    {
        public Event()
        {

        }
        public Event(EventType type, int App)
        {
            EventType = type;
            this.App = App;
        }

        public int App { get; set; } = -1;
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    }
}
