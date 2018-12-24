using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.pathshala.Models.Dto
{
    public class GradeModel
    {
        public Grade Grade { get; set; }
        public IEnumerable<NameValuePairModel> Teachers { get; set; }
        public IEnumerable<NameValuePairModel> Schools { get; set; }
        public IEnumerable<NameValuePairModel> Grades { get; set; }
    }
}