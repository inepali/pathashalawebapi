using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.pathshala.Models
{
    partial class Person
    {
        public string DisplayFullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }

            set { }
        }
    }
}