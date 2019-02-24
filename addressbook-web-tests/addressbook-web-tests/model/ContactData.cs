using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAaddressbookTests
{
    [Table (Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string phoneWithPrefix;
        private string mobilephoneWithPrefix;
        private string workphoneWithPrefix;
        public string Address;
        

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

        //пустой конструктор
        public ContactData()
        {
            
        }

        //возвращает строковое представление объектов типа ContactData(имя,фамилия)     
        public override string ToString()
        {
            // return "Lastname" + Lastname + "Firtsname=" + Firstname;
            // return "Lastname=" + Lastname + "Firtsname=" + Firstname+ "\ntitle=" + Title + "\naddress=" + Address;
           
            return Regex.Replace((Firstname + Middlename + Lastname + Title + Company  + PhoneWithPrefix + MobilePhoneWithPrefix + WorkPhoneWithPrefix + FirstEmail + SecondEmail + ThirdEmail), @"[\r\n  ]", "");
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
            return Lastname + Firstname == other.Lastname + Firstname;
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

        public string Title { get; set; }
        [Column(Name = "company"), NotNull]
        public string Company { get; set; }
        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }
        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }
        [Column(Name = "middlename"), NotNull]
        public string Middlename { get; set; }
        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string FirstEmail { get; set; }
        public string SecondEmail { get; set; }
        public string ThirdEmail { get; set; }
        
        [Column(Name = "id"), PrimaryKey, Identity]//NOTNull , Primary ,Identity важно тогда когда мы пишем в базу 
        public string Id { get; set; }
        [Column(Name = "deprecated"), NotNull]
        public TimeSpan Deprecated { get; set; }





        public string AllPhones
        {
            get
            {
                if (allPhones != null || allPhones == "")
                {
                    return allPhones;
                }
                //если пусто хоть в одном , тогда клеим в кучку, очистив предварительно от мусора
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
            }
            set
            {
                allPhones = value;
            }
        }

        //делаем строку для сравнения
        public string PhoneWithPrefix
        {
            get
            {
                if (phoneWithPrefix == null || phoneWithPrefix == "")
                {
                    return "\r\n";
                    
                }
                return "H:" + phoneWithPrefix;
            }
            set
            {
                phoneWithPrefix = value;
            }
        }
        public string MobilePhoneWithPrefix
        {
            get
            {
                if (mobilephoneWithPrefix == null || mobilephoneWithPrefix == "")
                {
                    return "\r\n";
                }
                return "M:" + mobilephoneWithPrefix;
            }
            set
            {
                mobilephoneWithPrefix = value;
            }
        }

        internal static List<ContactData> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public string WorkPhoneWithPrefix
        {
            get
            {
                if (workphoneWithPrefix == ""  || workphoneWithPrefix == null)
                {
                    
                    return "\r\n";
                }
                return "W:" + workphoneWithPrefix;
            }
            set
            {
                workphoneWithPrefix = value;
            }
        }

        //метод удаляет все нежелательные символы
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

           return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
         //   return Regex.Replace(phone,"[ -()]", "")+"\r\n";

        }
//
        public string AllEmails
        { 
            get
            {
                if (allEmails != null || allEmails == "")
                {
                    return allEmails;
                }
                //если пусто хоть в одном , тогда клеим в кучку
                return (CleanUp(FirstEmail) + CleanUp(SecondEmail) + CleanUp(ThirdEmail)).Trim();
            }
            set
            {
                allEmails = value;
            }
}
        public static List<ContactData> GetAllContactFromTable()
        {

            using (AddressBookDB db = new AddressBookDB())
            {
                
                return (from g in db.Contacts select g).ToList();

            }
        }

    }
    }


