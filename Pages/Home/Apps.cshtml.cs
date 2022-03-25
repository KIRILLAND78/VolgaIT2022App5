using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.Pages.Home
{
    [Authorize]
    public class AppsModel : PageModel
    {
        [BindProperty]
        public List<App> UserAppList { get; set; }
        public void OnGet()
        {UserAppList = new List<App>();
            App a = new App();
            a.Name = "uuga";
            a.Desc = "wuuga";
            a.owner = 5;
            a.Id = 5;
            UserAppList.Add(a);
            App b = new App();
            b.Name = "uuga2";
            b.Desc = "wuuga2";
            b.owner = 5;
            b.Id = 6;
            UserAppList.Add(b);
        }
    }
}
