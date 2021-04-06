using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.StudentData;
using System;

namespace StudentApi.Controllers
{
    
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentData _studentdata;
       public StudentController(IStudentData studentdata)
        {
            _studentdata = studentdata;
        }
        [HttpGet]
        [Route("api/[controller]")]
  
        public IActionResult GetStudent()
        {
            return Ok(_studentdata.GetStudent());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetStudent(Guid id)
        {
            var student = _studentdata.GetStudent(id);
            if(student!= null)
            {
                return Ok(_studentdata.GetStudent(id));
            }

            return NotFound($"Student with this id: {id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddStudent(Student student )
        {
         _studentdata.AddStudent(student);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path +"/"+ student.ID, student);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteStudent(Guid id)
        {
           var student=  _studentdata.GetStudent(id);
            if(student!= null)
            {
                _studentdata.DeleteStudent(student);
                return Ok();
            }

            return NotFound($"Student with this id: {id} was not found");
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditStudent(Guid id, Student student)
        {
            var existingStudent = _studentdata.GetStudent(id);
            if (existingStudent != null)
            {
                student.ID= existingStudent.ID;
                _studentdata.EditStudent(student);
                
            }

            return Ok();

        }
    }
}
