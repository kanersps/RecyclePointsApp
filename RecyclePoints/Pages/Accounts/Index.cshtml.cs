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
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if(!string.IsNullOrEmpty(Request.Query["account"])) {

                ulong AccountId = ulong.Parse(Request.Query["account"]);
                int Points = int.Parse(Request.Query["points"]);

                Debug.WriteLine($"Account: {AccountId}; points: {Points}");

                if (AccountId < 0)
                {
                    return;
                }

                RContext context = new RContext();

                Account acc = context.Accounts.Where(e => e.AccountId == AccountId).FirstOrDefault();

                acc.Points += Points;

                context.SaveChanges();
            }
        }

        public void OnPost()
        {
            
        }
    }
}
