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
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var client = Client.Create("Ferrad", "Rosé", Card.Create(CardType.Classic));
                    var client1 = Client.Create("Mael", "LaRochelle", Card.Create(CardType.Classic));
                    var client2 = Client.Create("Armel", "Taty", Card.Create(CardType.Classic));
                    var client3 = Client.Create("Carmel", "Taty", Card.Create(CardType.Classic));
                    
                    session.SaveOrUpdate(client);

                    session.SaveOrUpdate(client1);
                    session.SaveOrUpdate(client2);
                    session.SaveOrUpdate(client3);

                    transaction.Commit();
                                        
                }
            }           
        }
    }
}

