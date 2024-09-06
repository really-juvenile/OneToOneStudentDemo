using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OneToOneStudentDemo.Models;

namespace OneToOneStudentDemo.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.CourseName);
            Map(a => a.Description);
            References(a => a.Student).Column("student_id").Unique().Cascade.None();
        }
    }
}