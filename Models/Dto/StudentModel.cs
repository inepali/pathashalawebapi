using System.Collections.Generic;

namespace com.pathshala.Models.Dto
{
    public class StudentModel
    {
        public Student Student { get; set; }
        public IEnumerable<NameValuePairModel> Schools { get; set; }
        public IEnumerable<NameValuePairModel> Grades { get; set; }
    }
}