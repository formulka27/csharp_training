using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests
{
    public class ContactData
    {
        //объявляем поля
        private string firstname;
        private string lastname;
        //значения по умолчанию можно и не указывать
        private string middlename = "";
        private string nickname = "";

        //создаем конструктор для класса ContactData
        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        //описываем свойства объекта , их два
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                lastname = value;
            }
        }

    }

}
