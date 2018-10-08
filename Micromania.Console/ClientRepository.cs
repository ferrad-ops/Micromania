using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class ClientRepository : Repository<Client>
    {
        public IReadOnlyList<ClientDto> GetClientList()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Client>()
                    .ToList() // Fetch data into memory
                    .Select(x => new ClientDto(x.Id, x.MoneyInWallet))
                    .ToList();
            }
        }
    }
}
