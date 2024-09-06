﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using OneToOneStudentDemo.Mappings;
using NHibernate.Tool.hbm2ddl;

namespace OneToOneStudentDemo.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory = null;
        public static ISession CreateSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<StudentMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }
    }
}