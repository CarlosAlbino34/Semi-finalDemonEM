using System.Text.Json.Serialization;
namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        // One to many connection or relationship with Department
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}
