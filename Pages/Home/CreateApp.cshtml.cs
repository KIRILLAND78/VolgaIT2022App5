using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.Pages.Home
{
    [Authorize]
    public class CreateAppModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
