using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyFamily.Models
{
    public static class AuthenticationModule
    {
        //get account from account database
        private static List<Account> Accounts = new List<Account>();

        public static bool CheckAccount(string username, string password)
        {
            foreach (var acc in Accounts)
            {
                if(acc.Username==username && acc.Password==password)
                {
                    return true;
                }
            }
            return false;
        }

        public static Account GetAccount(string username)
        {
            foreach(var acc in Accounts)
            {
                if (acc.Username == username)
                    return acc;
            } return new Account();
        }

        public static void AddAccount(string username, string password, User user)
        {
            Accounts.Add(new Account(username, password, user));
        }

        public static void AddAccount(Account acc)
        {
            Accounts.Add(acc);
        }
    }
}