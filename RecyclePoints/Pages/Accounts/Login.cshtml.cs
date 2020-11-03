using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecyclePoints.Core.Database;
using RecyclePoints.Core.Database.Models;

namespace RecyclePoints.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            string token = Request.Cookies["token"];

            Debug.WriteLine($"Token: {token}");
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public ActionResult OnPost()
        {
            RContext context = new RContext();
            Account account = context.Accounts.Where(u => u.Username == Username).FirstOrDefault();

            if(account == null)
            {
                return Content("Incorrecte gebruikersnaam en/of wachtwoord! u wordt automatisch terug gestuurd <script>setTimeout(() => { window.location.href='/' }, 5000)</script>", "text/html");
            } else
            {
                if (BCrypt.Net.BCrypt.Verify(Password, account.Password))
                {
                    Auth auth = context.Auth.Where(a => a.Username == Username).FirstOrDefault();

                    if (auth == null)
                        return Content("Een fout is gebeurd, rapporteer dit!", "text/html");
                    else
                    {
                        Response.Cookies.Append("token", auth.Token);
                        return new RedirectResult("Index");
                    }
                } else
                {
                    return Content("Incorrecte gebruikersnaam en/of wachtwoord! u wordt automatisch terug gestuurd <script>setTimeout(() => { window.location.href='/' }, 5000)</script>", "text/html");
                }
            }
        }
    }
}
