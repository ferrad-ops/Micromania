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
        public IEnumerable<ServerData> GetServerData()
        {
            return serverDataRepository.GetAll();
        }


    }
}
