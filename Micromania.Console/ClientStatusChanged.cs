using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class ClientStatusChanged : IDomainEvent
    {
        public ClientStatusChanged()
        {
        }

        public ClientStatusChanged(Client client) : this()
        {           
        }

        public Client Client { get; }
    }
}
