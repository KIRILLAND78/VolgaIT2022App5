using VolgaIT2022App5.Models;
using VolgaIT2022App5.DBContexts;

namespace VolgaIT2022App5.DBworkers
{
    public class EventsWorker
    {
        public static void AddEvent(EventType type, string app)
        {
            Event ev = new Event(type, AppsWorker.IdentityToId(app));
            using (EventContext db = new EventContext())
            {
                db.Add(ev);
                db.SaveChanges();
            }
        }
        public static List<Event> GetEventList(string Identity)
        {
            List<Event> eventsList = new List<Event>();

            int oid = AppsWorker.IdentityToId(Identity);

            using (EventContext db = new EventContext())
            {
                foreach (Event entry in db.Events.Where(b => b.App == oid))
                {
                    eventsList.Add(entry);
                }
            }
            return eventsList;
        }
        public static List<Event> GetEventList(string Identity, EventType ET)
        {
            List<Event> eventsList = new List<Event>();

            int oid = AppsWorker.IdentityToId(Identity);

            using (EventContext db = new EventContext())
            {
                foreach (Event entry in db.Events.Where(b => b.App == oid).Where(b => b.EventType == ET))
                {
                    eventsList.Add(entry);
                }
            }
            return eventsList;
        }
        public static List<Event> GetEventList(string Identity, EventType ET, int days)
        {
            List<Event> eventsList = new List<Event>();

            int oid = AppsWorker.IdentityToId(Identity);

            using (EventContext db = new EventContext())
            {
                foreach (Event entry in db.Events.Where(b => b.App == oid).Where(b => b.EventType == ET).Where(b=> b.DateCreated >= DateTime.Now.AddDays(-days)))
                {
                    eventsList.Add(entry);
                }
            }
            return eventsList;
        }

    }
}
