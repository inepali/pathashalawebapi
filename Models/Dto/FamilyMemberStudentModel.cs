
using System.Collections.Generic;

namespace com.pathshala.Models.Dto
{
    public class FamilyMemberStudentModel
    {
        public FamilyMemberStudent FamilyMemberStudent { get; set; }
        public IEnumerable<NameValuePairModel> RelationshipTypes { get; set; }
    }
}