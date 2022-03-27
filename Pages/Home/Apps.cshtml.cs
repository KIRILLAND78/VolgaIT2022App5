using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VolgaIT2022App5.Models;
using VolgaIT2022App5.DBworkers;

namespace VolgaIT2022App5.Pages.Home
{
    [Authorize]
    public class AppsModel : PageModel
    {
        [BindProperty]
        public List<App> UserAppList { get; set; }

        public int GetCount(string identity, EventType type)
        {
            return EventsWorker.GetEventList(identity, type).Count;
        }

        public void OnGet()
        {UserAppList = new List<App>();
            UserAppList = AppsWorker.GetAppList(HttpContext.User.Identity.Name);

        }
    }
}
