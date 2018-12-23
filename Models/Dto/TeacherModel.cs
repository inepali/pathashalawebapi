using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.pathshala.Models.Dto
{
    public class TeacherModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<NameValuePairModel> Schools { get; set; }
        //public IEnumerable<NameValuePairModel> Roles { get; set; }
    }
}