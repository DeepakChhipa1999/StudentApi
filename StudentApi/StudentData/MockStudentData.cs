using StudentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.StudentData
{
    
    public class MockStudentData : IStudentData
    {
        private List<Student> students = new List<Student>()
    {
        new Student(){
        ID = Guid.NewGuid(),
        FirstName = "Deepak",
            LastName = "Chhipa",
            Rollno = 45

        },
        new Student(){
        ID = Guid.NewGuid(),
        FirstName = "Shubham",
            LastName = "sharma",
            Rollno = 65
        }
        };
        public Student AddStudent(Student student)
        {
            student.ID = Guid.NewGuid();
            students.Add(student);
            return student;
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

        public Student EditStudent(Student student)
        {
            var existingStudent = GetStudent(student.ID);
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Rollno = student.Rollno;
            return existingStudent;
        }

        public Student GetStudent(Guid id)
        {
            return students.SingleOrDefault(x => x.ID == id);
        }

        public List<Student> GetStudent()
        {
            return students;
        }
    }
}
