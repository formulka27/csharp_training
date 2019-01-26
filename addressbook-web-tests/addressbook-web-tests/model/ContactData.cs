using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
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
        //возвращает строковое представление объектов типа ContactData(имя,фамилия)     
        public override string ToString()
        {
            return "Lastname" + lastname + "Firtsname=" + firstname;
                
        }
        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname+Firstname == other.Lastname+Firstname;
        }
        //сравнение
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return -1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0 && Firstname.CompareTo(other.Firstname) == 0)
            {
                return 0;
            }
            else if (Lastname.CompareTo(other.Lastname) == 1 && Firstname.CompareTo(other.Firstname) == 0 || Firstname.CompareTo(other.Firstname) == 1 || Firstname.CompareTo(other.Firstname) == -1)
            {
                return 1;
            }
            else if (Lastname.CompareTo(other.Lastname) == -1 && Firstname.CompareTo(other.Firstname) == 0 || Firstname.CompareTo(other.Firstname) == 1 || Firstname.CompareTo(other.Firstname) == -1)
            {
                return -1;
            }
            return -1;

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
