using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;

namespace addressbook_test_autoit
{
   
    public class GroupHelper :HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETETITLE= "Delete group";

        public List<GroupData> list { get; private set; }

        public void Remove()
       {
            OpenGroupsDialogue();
            string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                     "Select", "#0|#0", "");//выбрали первый элемент в группе
           
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");//кликнули на Delete
            aux.ControlClick(GROUPDELETETITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");//кликнули на ok  в окошке Delete group    

            CloseGroupsDialogue();

                }

        private void SelectGroupForRemoval()
        {
            throw new NotImplementedException();
        }

        ///
        public GroupHelper(ApplicationManager manager) : base(manager)
        { }
/// 
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();        

            string count=aux.ControlTreeView(
                 GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount","#0","");

            for (int i = 0; i < int.Parse(count);i++)
            {
                string item =aux.ControlTreeView(
                     GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                      "GetText", "#0|#"+i,"");

                list.Add(new GroupData()
                {
                    Name = item
                });

            }
                CloseGroupsDialogue();
            return list;
            

/////
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");//кликнули на new
            aux.Send(newGroup.Name);//передали значение имени группы и ввели
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }
/// 
        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }
/// 
        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}