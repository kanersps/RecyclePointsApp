using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecyclePoints.Core.Database.Models
{
    public class Account
    {
        [Key]
        public UInt64 AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
    }
}
