using StudentApi.Models;
using System;
using System.Linq;
using System.Collections.Generic;



namespace StudentApi.StudentData
{
    public class SqlStudentData : IStudentData
    {
        private StudentContext _studentcontext;
        public SqlStudentData(StudentContext studentContext){
            _studentcontext = studentContext;
        }
        public Student AddStudent(Student student)
        {
            student.ID = Guid.NewGuid();
            _studentcontext.Students.Add(student);
            _studentcontext.SaveChanges();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _studentcontext.Students.Remove(student);
            _studentcontext.SaveChanges();
        }

        public Student EditStudent(Student student)
        {
           var existingstudent = _studentcontext.Students.Find(student.ID);
            if (existingstudent != null)
            {
                existingstudent.FirstName = student.FirstName;
                existingstudent.LastName = student.LastName;
                existingstudent.Rollno = student.Rollno;
                _studentcontext.Students.Update(existingstudent);
                _studentcontext.SaveChanges();
            }
            return student;
        }

        public List<Student> GetStudent()
        {
            return _studentcontext.Students.ToList();
        }

        public Student GetStudent(Guid id)
        {
            var student= _studentcontext.Students.Find(id);
            return student;
        }
    }
}
