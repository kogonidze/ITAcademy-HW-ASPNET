using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace SimpleAuthorization
{
    public class Authorization
    {
        private static Dictionary<string, string> authDictionary;

        public static UserModel Run(string[] args)
        {
            FillAuthDictionary();

            var login = args[0];

            var passwd = args[1];

            if (!authDictionary.ContainsKey(login))
            {
                throw new AuthenticationException();
            }

            var realPasswd = authDictionary[login];

            if (passwd != realPasswd)
            {
                throw new AuthenticationException();
            }

            return new UserModel() {Username = login};
        }

        private static void FillAuthDictionary()
        {
            authDictionary.Add("admin", "root");
            authDictionary.Add("user1", "kiTTy2001");
        }
    }
}
