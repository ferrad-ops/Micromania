using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Presentation.Data
{
    public class ClientDataService : IClientDataService
    {
        public IEnumerable<Client> GetAll()
        {
            yield return Client.Create("ferrad", "Rosé");   
            yield return Client.Create("ferrad", "Rosé");   
            yield return Client.Create("ferrad", "Rosé");
        }
    }
}

