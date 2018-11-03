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

namespace Micromania.Infrastructure
{
    public class SessionFactory
    {
        private static ISessionFactory _factory;

        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);
        }

        public static ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
                
            return configuration.BuildSessionFactory();
        }
    }
}
