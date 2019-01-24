using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Account
    {
        public int accountId;
        public string email;
        public string userLogIn;
        public string password;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string UserLogin
        {
            get { return userLogIn; }
            set { userLogIn = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
