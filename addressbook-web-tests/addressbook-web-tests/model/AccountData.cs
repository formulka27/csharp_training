using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests
{
    public class AccountData
    {
        private string username;
        private string password;
//конструктор для класса AccountData
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
//свойства аккааунта
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
            public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
                    

        }

    }
}

