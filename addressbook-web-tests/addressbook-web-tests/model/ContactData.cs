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
        //private string firstname;
        //private string lastname;
        ////значения по умолчанию можно и не указывать
        //private string middlename = "";
        //private string nickname = "";

        //создаем конструктор для класса ContactData
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        //возвращает строковое представление объектов типа ContactData(имя,фамилия)     
        public override string ToString()
        {
            return "Lastname" + Lastname + "Firtsname=" + Firstname;
                
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
        
        



        //описываем свойства объекта 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Id { get; set; }

    }

}
