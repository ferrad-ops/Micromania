using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class NHibernateHelper
    {
        private static ISessionFactory _factory;

        private static ISessionFactory Factory
        {
            get
            {
                if (_factory == null)
                    CreateSessionFactory();

                return _factory;
            }
        }

        public static void CreateSessionFactory()
        {
            _factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=DESKTOP-H9JQ47G;Database= Micromania;Trusted_Connection=True;"))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return Factory.OpenSession();
        }
    }
}
