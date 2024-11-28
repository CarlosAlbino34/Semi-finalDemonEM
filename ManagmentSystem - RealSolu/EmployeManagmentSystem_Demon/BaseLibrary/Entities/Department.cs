using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        //Many to one relatioship with general Department
        public GeneralDepartment? GeneralDepartment { get; set; }

        public int GeneralDepartmentId { get; set; }

        //One to many connection or relationship with Branch
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
