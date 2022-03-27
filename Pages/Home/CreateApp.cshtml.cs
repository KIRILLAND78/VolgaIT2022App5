using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.Pages.Home
{
    [Authorize]
    public class CreateAppModel : PageModel
    {
        [BindProperty]
        public App NewApp { get; set; } = new();


        public async Task<IActionResult> OnPostAsync()
        {
            NewApp.Identity = DBworkers.AppsWorker.IdentityCreator();
            if (ModelState.IsValid)
            {
                //addUser
                bool app = DBworkers.AppsWorker.CheckName(HttpContext.User.Identity.Name, NewApp.Name);

                if (app == true)
                {
                    ModelState.AddModelError(string.Empty, "Приложение уже существет в бд.");
                    return Page();
                }
                DBworkers.AppsWorker.CreateApp(NewApp, HttpContext.User.Identity.Name);

                return RedirectToAction("Apps", "Home");
            }

            // Something failed. Redisplay the form.
            return Page();
        }
    }
}
