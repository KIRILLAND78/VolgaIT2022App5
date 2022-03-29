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
        public List<string> appsView { get; set; } = new List<string>();
        [BindProperty]
        public App CApp { get; set; }

        [BindProperty]
        public int days { get; set; } = 0;

        public void OnGet(string AList)
        {
            if (AList != "")
            {
                CApp = AppsWorker.FindById(AppsWorker.IdentityToId(AList));
            }
                this.AList = new List<SelectListItem>();
                foreach (App app_ in AppsWorker.GetAppList(HttpContext.User.Identity.Name))
                {
                    this.AList.Add(new SelectListItem { Text = app_.Name, Value = app_.Identity });
                }
            

        }
    }
}
