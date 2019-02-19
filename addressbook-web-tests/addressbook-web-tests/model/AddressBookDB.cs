using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAaddressbookTests
{
    public class AddressBookDB:LinqToDB.Data.DataConnection //объясняем системе что это база данных,наследуем от спец класса
    {
        // какой именно коннектион мы будем использовать
        public AddressBookDB() : base("AddressBook") { }
        //для каждой таблице в бд надо написать метод ,который возвращает таблицу данных 
        public ITable<GroupData> Groups {get { return GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        
        }

    }

