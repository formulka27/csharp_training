using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using LinqToDB.Mapping;


namespace WebAaddressbookTests
{
    [Table(Name= "address_in_groups" )]
    public class GroupContactRelation : AuthTestBase
    {
        [Column(Name = "group_id")]
        public string GroupId{ get; }
        [Column(Name = "id")]
        public string ContactId{ get; }
    }
}
