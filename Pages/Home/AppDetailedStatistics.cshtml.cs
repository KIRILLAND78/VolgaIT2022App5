using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolgaIT2022App5.Models;
using VolgaIT2022App5.DBworkers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VolgaIT2022App5.Pages.Home
{
    public class AppDetailedStatisticsModel : PageModel
    {
        [BindProperty]
        public List<SelectListItem> AList { get; set; }
        [BindProperty]
        public List<SelectListItem> TimePeriodList { get; set; } 
        [BindProperty]
        public App CApp { get; set; }

        [BindProperty]
        public List<Event> EventsList { get; set; }
        [BindProperty]
        public Dictionary<string, int> EventsDictDatePOST { get; set; } = new();
        [BindProperty]
        public Dictionary<string, int> EventsDictDateGET { get; set; } = new();
        [BindProperty]
        public int days { get; set; } = 0;

        public string[] GetKeys(Dictionary<string, int> d)
        {
            string[] keys= new string[d.Count];
            d.Keys.ToArray().CopyTo(keys, 0);
            return keys;
        }
        public int[] GetValues(Dictionary<string, int> d)
        {
            int[] vals = new int[d.Count];
            d.Values.ToArray().CopyTo(vals, 0);
            return vals;
        }

        public void OnGet(string AList, string TimePeriodList)
        {
            if (AList != "")
            {
                CApp = AppsWorker.FindById(AppsWorker.IdentityToId(AList));
            }
            switch (TimePeriodList)
            {
                case "1":
                    days = 1;
                    break;
                case "2":
                    days = 7;
                    break;
                case "3":
                    days = 30;
                    break;
                case "4":
                    days = 365;
                    break;
                case "0":
                    days = -1;
                    break;
                default:
                    days = -1;
                    break;

            }
            EventsList = new List<Event>();
            foreach (Event s in EventsWorker.GetEventList(AList, days)){
                EventsList.Add(s);
            }
            if (TimePeriodList != "4")
            {
                for (int a = days-1; a >= 0; a--)
                {
                    DateTime f = DateTime.Today;
                    f = f.AddDays(-a);
                    string temp =DateTime.SpecifyKind(f, DateTimeKind.Utc).ToShortDateString();
                    EventsDictDateGET.TryAdd(temp, 0);
                    EventsDictDatePOST.TryAdd(temp, 0);
                }
                
                    foreach (Event s in EventsWorker.GetEventList(AList, EventType.GET, days))
                {
                    EventsDictDateGET.TryAdd(s.DateCreated.ToShortDateString(), 0);
                    EventsDictDateGET[s.DateCreated.ToShortDateString()] += 1;
                }
                foreach (Event s in EventsWorker.GetEventList(AList, EventType.POST, days))
                {
                    EventsDictDatePOST.TryAdd(s.DateCreated.ToShortDateString(), 0);
                    EventsDictDatePOST[s.DateCreated.ToShortDateString()] += 1;
                }
            }
            else {
                string[] months = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь","Декабрь"};
                for (int a = 0; a < 12; a++)
                {
                    EventsDictDateGET.Add(months[a], 0);
                    EventsDictDatePOST.Add(months[a], 0);
                }
                foreach (Event s in EventsWorker.GetEventList(AList, EventType.GET, days))
                {
                    EventsDictDateGET[months[s.DateCreated.Month-1]] += 1;
                }
                foreach (Event s in EventsWorker.GetEventList(AList, EventType.POST, days))
                {
                    EventsDictDatePOST[months[s.DateCreated.Month-1]] += 1;
                }

            }

            this.TimePeriodList = new List<SelectListItem>();
            this.TimePeriodList.Add(new SelectListItem { Text = "Всё время", Value = "0" });
            this.TimePeriodList.Add(new SelectListItem { Text = "Неделя", Value = "2" });
            this.TimePeriodList.Add(new SelectListItem { Text = "Месяц", Value = "3" });
            this.TimePeriodList.Add(new SelectListItem { Text = "Год", Value = "4" });
            this.AList = new List<SelectListItem>();
            foreach (App app_ in AppsWorker.GetAppList(HttpContext.User.Identity.Name))
                {
                    this.AList.Add(new SelectListItem { Text = app_.Name, Value = app_.Identity });
                }
            

        }
    }
}
