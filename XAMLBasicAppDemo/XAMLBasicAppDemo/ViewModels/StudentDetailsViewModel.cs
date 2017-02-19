using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAMLBasicAppDemo.Models;

namespace XAMLBasicAppDemo.ViewModels
{
    public class StudentDetailsViewModel
    {
        private List<Student> _students;

        public StudentDetailsViewModel()
        {
            _students = GetAllStudents();
        }

        private List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "Ram", Department = "IT" });
            students.Add(new Student { Id = 2, Name = "Shyam", Department = "CS" });
            students.Add(new Student { Id = 3, Name = "Seeta", Department = "ME" });
            students.Add(new Student { Id = 4, Name = "Geeta", Department = "EC" });
            return students;
        }

        public List<Student> Students
        {
            get { return _students; }
        }
    }
}
