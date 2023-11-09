using SQLite;

namespace Contacts.Maui.Models
{
    public class Department
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public Department Clone() => MemberwiseClone() as Department;
    }


    /*
     * FOR SQL SERVER
     public class Department
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
    }
     */
}
