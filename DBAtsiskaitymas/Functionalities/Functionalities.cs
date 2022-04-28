using DBAtsiskaitymas.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace DBAtsiskaitymas.Functionalities
{
    
    public class DataProcedures
    {

        public static UniversityContext _context = new ();
        public Lecture AddLecture(string name)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.Name == name);
            if (lecture == null)
            {
                _context.Add(lecture = new Lecture { Name = name });
                _context.SaveChanges();
            }
            return _context.Lectures.FirstOrDefault(x => x.Name == name);
        }
        public Department CreateDepartmentWithLectures(string departmentName, List<Lecture> lectures)
        {

            var department = _context.Departments.SingleOrDefault(x => x.Name == departmentName);
            if (department == null)
            {
                _context.Departments.Add(new Department { Name = departmentName, Lectures = lectures });
                _context.SaveChanges();
            }
            return _context.Departments.FirstOrDefault(x => x.Name == departmentName); 
        }
        
        public Student AddStudent(string name, string lastName, Department department, List<Lecture> lectures)
        {
            if (_context.Students.FirstOrDefault(x => x.Name == name && x.LastName == lastName) == null)
            {
                _context.Students.Add(new Student { Name = name, LastName = lastName, Department = department, Lectures = lectures });
                _context.SaveChanges();
            }
            return _context.Students.FirstOrDefault(x=>x.Name == name&& x.LastName == lastName);

        }

        public Student TransferStudent(string name, string lastName, Department department, List<Lecture> lectures)
        {
            var student = _context.Students.Where(x => x.Name == name && x.LastName == lastName).Include(x => x.Lectures).FirstOrDefault();
            student.Department = department;
            student.Lectures = lectures;
            _context.SaveChanges();
            return _context.Students.FirstOrDefault(x => x.Name == name && x.LastName == lastName);

        }
    }
}
