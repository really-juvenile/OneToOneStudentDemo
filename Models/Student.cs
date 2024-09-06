using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneToOneStudentDemo.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public virtual string Name { get; set; }
        [Required]
        [Range(18, 70)]
        public virtual int Age { get; set; }
        [Required]
        [EmailAddress]
        [GmailValidator]
        public virtual string Email { get; set; }

        public virtual Course Course { get; set; }
    }
}