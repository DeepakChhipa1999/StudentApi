using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Models
{
    public class Student
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="First Name must be not not exceed the limit")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last Name must be not not exceed the limit")]
        public string LastName { get; set; }

        [Required]
       public int Rollno { get; set; }
    }
}
