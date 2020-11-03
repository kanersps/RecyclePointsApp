using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecyclePoints.Core.Database.Models
{
    public class Auth
    {
        [Key]
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
