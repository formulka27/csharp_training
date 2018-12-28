using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests

{
    public class GroupData
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
