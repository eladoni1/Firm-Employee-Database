using MongoDB.Bson;

namespace WebApplication2.Models
{
    public class Department
    {
        public ObjectId Id { get; set; }
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
