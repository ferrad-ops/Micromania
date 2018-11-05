using Micromania.Domain;
using Micromania.Domain.Aggregates;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Micromania.Infrastructure
{
    public abstract class Repository<T>
        where T : AggregateRoot
    {
        public void Add(T aggregateRoot)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(aggregateRoot);
                transaction.Commit();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var all = session.CreateCriteria(typeof(T)).List<T>();
                return all;
            }
        }

        public T GetById(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<T>(id);               
            }
        }

        public void Save(T aggregateRoot)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(aggregateRoot);
                transaction.Commit();
            }
        }

        public void Delete(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var client = session.Get<T>(id);

                if (client == null)
                    throw new ArgumentNullException();

                session.Delete(client);
                transaction.Commit();
            }
        }
    }
}
