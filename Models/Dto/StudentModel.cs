using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.pathshala.Models.Dto
{
    public class StudentModel
    {
        public Student Student { get; set; }
        public IEnumerable<NameValuePairModel> Schools { get; set; }
        //public IEnumerable<NameValuePairModel> Roles { get; set; }
    }
}