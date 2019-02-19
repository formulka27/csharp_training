using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAaddressbookTests

{
    [Table (Name = "group_list")]
  
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        //объявляем поля
        //        private string name;
        //создаем конструктор для объекта группы
        public GroupData(string name)
        {
            Name = name;
        }
        //пустой
        public GroupData()
        {
            
        }

        //сравненниев 2 этапа , 1)hashcode2)equils
        //хэш это просто число ,строится он быстро , у равных объектов хэши равные ,  а у разных чаще всего разные
        //короче, если хэши разные, то объекты 100% разные

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        //возвращает строковое представление объектов типа GroupData(имя группы)     
        public override string ToString()
        {
            return "name=" + Name+"\nheader="+Header+"\nfooter="+Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1; //если второй элемент ,с которым сравниваем =null, т.е. наш текущий объект больше 
            }
            return Name.CompareTo(other.Name);//если не null, то можно и имена сравнить два списка


        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
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
        //если методы обращения к свойствам выглядят примитивно  можно использовать методы с автоматической  идентификацией
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        //идентично 
        [Column (Name="group_name"),NotNull]
        public string Name { get; set; }
        //еще и объявление поля строка 13 можно убрать , оно создается автоматически при вызове метода
        //идентично 
        [Column(Name = "group_header"),NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"),NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"),PrimaryKey,Identity]//NOTNull , Primary ,Identity важно тогда когда мы пишем в базу 
        public string Id { get; set; }
    }      

    }

