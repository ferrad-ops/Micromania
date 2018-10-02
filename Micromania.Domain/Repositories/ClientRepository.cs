using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain.Repositories
{
    public class ClientRepository : Repository<Client>
    {
        public IReadOnlyList<ClientDto> GetClientList()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Client>()
                    .ToList() // Fetch data into memory
                    .Select(x => new ClientDto())
                    .ToList();
            }
        }
    }
}
