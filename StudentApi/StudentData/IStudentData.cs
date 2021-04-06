
using StudentApi.Models;
using System;
using System.Collections.Generic;

namespace StudentApi.StudentData
{
    public interface IStudentData
    {
        List<Student> GetStudent();

        Student GetStudent(Guid id);

        Student AddStudent(Student student);

        void DeleteStudent(Student student);

        Student EditStudent(Student student);

    }
}
