using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Account
    {
        private string username;
        private string password;
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public Account()
        {

        }
        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public override string ToString()
        {
            return username;
        }
    }
}
