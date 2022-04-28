using System;
using System.Linq;
using DBAtsiskaitymas.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DBAtsiskaitymas.Functionalities
{
    public class Printer
    {
        private static UniversityContext _context { get; set; } = new();
        public void ViewAllStudentsByDepartment(Department departmentName)
        {
            Console.WriteLine($"---{departmentName} studentai----");
            var students = _context.Students.Include(x=>x.Department).Where(x=>x.Department==departmentName).ToList();
            foreach(var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.LastName}, {student.Department}");
            }
            Console.WriteLine("-------");
        }
        public void ViewAllLecturesByDepartment(Department department)
        {
            Console.WriteLine($"---{department.Name} paskaitos----");
            var lectures = _context.Lectures.Include(x => x.Departments).Where(x => x.Departments.Contains(department));
            foreach(var lecture in lectures)
            {
                Console.WriteLine($"{lecture.Name}");
            }
            Console.WriteLine("-------");
        }   
        public void ViewAllLecturesByStudent(Student student)
        {
            Console.WriteLine($"---{student.Name} {student.LastName } paskaitos----");
            Console.WriteLine($"----{student.Department}---------");
            var lectures = _context.Lectures.Include(x => x.Students).Where(x => x.Students.Contains(student));
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.Name}");
            }
            Console.WriteLine("-------");
        }
        
    }
}
