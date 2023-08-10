using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class ListAccount
    {
        private static ListAccount instance;
        public static ListAccount Instance
        {
            get
            {
                if (instance == null) instance = new ListAccount();
                return instance;
            }
        }
        List<Account> accountList;
        public List<Account> AccountList { get { return accountList; } set { accountList = value; } }
        public ListAccount()
        {
            accountList = new List<Account>();
            accountList.Add(new Account("minhbao", "2011356"));
            accountList.Add(new Account("thienan", "2011353"));
            accountList.Add(new Account("caotri", "123456"));
            accountList.Add(new Account("quoctrong", "123321"));
        }

        public void Them(Account tk)
        {
            accountList.Add(tk);
        }

        public override string ToString()
        {
            string s = "Danh sách tài khoản hoạt động:";
            foreach (object tk in accountList)
            {
                s += tk as Account;
            }
            return s;
        }

        public int AccountCount(string username)
        {
            Account account = new Account();
            int dem = 0;
            foreach (Account tk in accountList)
            {
                if (tk.Username == username)
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}
