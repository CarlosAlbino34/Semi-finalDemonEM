using System.Text.Json.Serialization;
namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        //Many to one relationship with department
        public Department? Department { get; set; } 
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public List<Employee>? Employees { get; set; } 
    }
}
