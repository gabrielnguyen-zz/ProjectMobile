using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class Account
    {
        public Account()
        {
            Actor = new HashSet<Actor>();
        }

        public string AccountId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Actor> Actor { get; set; }
    }
}
