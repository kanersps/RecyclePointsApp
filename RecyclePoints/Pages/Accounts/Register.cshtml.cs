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
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }

        private Random random = new Random();

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public ActionResult OnPost()
        {
            // do something with emailAddress
            Debug.WriteLine(Username);
            Debug.WriteLine(Password);

            RContext context = new RContext();

            Account account = context.Accounts.Where(user => user.Username == Username).FirstOrDefault();

            if (account != null)
            {
                return Content("Er bestaat al een gebruiker met deze gebruikersnaam, u wordt automatisch terug gestuurd <script>setTimeout(() => { window.location.href='/' }, 5000)</script>", "text/html");
            }
            else
            {
                context.Accounts.Add(new Account()
                {
                    AccountId = (ulong)random.Next(0, int.MaxValue),
                    Password = BCrypt.Net.BCrypt.HashPassword(Password),
                    Points = 0,
                    Username = Username
                });

                Auth auth = new Auth()
                {
                    Token = Guid.NewGuid().ToString(),
                    Username = Username
                };

                context.Auth.Add(auth);

                Response.Cookies.Append("token", auth.Token);

                context.SaveChanges();

                return new RedirectResult("Index");
            }
        }
    }
}
