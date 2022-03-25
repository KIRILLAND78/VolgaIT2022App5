using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolgaIT2022App5.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace VolgaIT2022App5.Pages
{
    public class registerModel : PageModel
    {
        [BindProperty]
        public RegUser NewUser { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(NewUser.Email);
            Console.WriteLine(NewUser.Email);
            if (ModelState.IsValid)
            {
                //addUser
                bool user = DBworkers.UserWorker.CheckMail(NewUser.Email);

                if (user == true)
                {
                    ModelState.AddModelError(string.Empty, "Почта уже существет в бд.");
                    return Page();
                }

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, NewUser.Email)
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                ////_logger.LogInformation("User {Email} logged in at {Time}.",
                //    user.Email, DateTime.UtcNow);
                return RedirectToAction("Index", "Home");
                //return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }

            // Something failed. Redisplay the form.
            return Page();
        }

    }
}
