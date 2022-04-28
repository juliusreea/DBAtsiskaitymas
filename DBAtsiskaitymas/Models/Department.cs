using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAtsiskaitymas
{
    public class Department
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Lecture> Lectures { get; set; } = new();

        public Department(string name)
        {
            Id = new();
            Name = name;
            Students = new List<Student>();
        }
        public Department()
        {

        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
