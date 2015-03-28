using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyFamily.Models
{
    public class Account
    {
        public bool Exists { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

        public Account()
        {
            this.Exists = false;
        }

        public Account(string Username, string Password, User User)
        {
            this.Username = Username;
            this.Password = Password;
            this.User = User;
            this.Exists = true;
        }
    }
}