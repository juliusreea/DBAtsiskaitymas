using System.Collections.Generic;

namespace DBAtsiskaitymas
{
    public class Lecture
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; } 
        public virtual List<Department> Departments { get; set; } 

        public Lecture(string name)
        {
            Id = new();
            Name = name;
        }
        public Lecture()
        {

        }
    }
}
