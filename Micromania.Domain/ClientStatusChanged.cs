using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class ClientStatusChanged : IDomainEvent
    {        
        public ClientStatusChanged()
        {            
        }

        public Client Client { get; set; }
    }
}
