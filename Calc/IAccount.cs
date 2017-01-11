using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public interface IAccount
    {
        int GetAccountId();
    }

    public class Account : IAccount
    {
        private int id;

        public Account(int id)
        {
            this.id = id;
        }

        public int GetAccountId()
        {
            Console.WriteLine("Account: GetAccountId() done");
            return id;
        }
    }

    public class AccountManager
    {
        private IAccount account;

        public AccountManager(IAccount account)
        {
            this.account = account;
        }

        public int AccountInfo()
        {
            Console.WriteLine("AccountManager: AccountInfo() done");
            return account.GetAccountId();
        }
    }
}
