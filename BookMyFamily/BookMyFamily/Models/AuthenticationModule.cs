using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyFamily.Models
{
    public static class AuthenticationModule
    {
        //get account from account database
        static List<Account> Accounts;

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


    }
}