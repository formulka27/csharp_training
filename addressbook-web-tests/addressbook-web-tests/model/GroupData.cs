using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests

{
    public class GroupData:IEquatable<GroupData>,IComparable<GroupData>
    {
        //объявляем поля
        private string name;
        private string header ="";
        private string footer = "";
        //создаем конструктор для объекта группы
        public GroupData(string name)
        {
            this.name = name;
        }
//сравненниев 2 этапа , 1)hashcode2)equils

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
   //возвращает строковое представление объектов типа GroupData(имя группы)     
        public override string ToString()
        {
            return "name="+Name;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return 1; //если второй элемент ,с которым сравниваем =null, т.е. наш текущий объект больше 
            }
            return Name.CompareTo(other.Name);//если не null, то можно и имена сравнить два списка


        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;

        }

        //свойства группы Name, Footer, Header     
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

    }
}
