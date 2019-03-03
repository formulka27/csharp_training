﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}