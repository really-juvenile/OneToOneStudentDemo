using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OneToOneStudentDemo.Models;

namespace OneToOneStudentDemo.Mappings
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Name);
            Map(u => u.Email);
            Map(u=>u.Age);
            HasOne(u => u.Course).Cascade.All()
                .PropertyRef(a => a.Student)
                .Constrained(); //Relationship Integrity COnstraint
        }

    }
}