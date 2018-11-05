using Micromania.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Infrastructure
{
    public class ClientRepository : Repository<Client>
    {
        //public IEnumerable<Client> GetClientList()
        //{
        //    using (ISession session = SessionFactory.OpenSession())
        //    {
        //        var clients =  session.CreateCriteria(typeof(Client)).List<Client>();
        //        return clients;                
        //    }
        //}
    }
}
