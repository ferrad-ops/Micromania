using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Micromania.Console
{
    public class ClientStatusChangedHandler : IHandler<ClientStatusChanged>
    {
        public ClientStatusChangedHandler()
        {
        }

        public void Handle(ClientStatusChanged domainEvent)
        {           
            System.Console.WriteLine($"Client status is now {domainEvent.Client.Status}");       
        }
    }
}
