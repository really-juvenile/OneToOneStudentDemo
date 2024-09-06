﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneToOneStudentDemo.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string CourseName { get; set; }

        public virtual string Description { get; set; }
        public virtual Student Student { get; set; }
    }
}