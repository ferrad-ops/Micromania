using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class StarStatusReachedHandler : IHandler<StarStatusReached>
    {
        public StarStatusReachedHandler()
        {
        }

        public void Handle(StarStatusReached domainEvent)
        {
            System.Console.WriteLine($"{domainEvent.Client.FirstName} reached STAR status.");
        }
    }
}
