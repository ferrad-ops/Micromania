using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class PremiumStatusReachedHandler : IHandler<PremiumStatusReached>
    {
        public PremiumStatusReachedHandler()
        {

        }

        public void Handle(PremiumStatusReached domainEvent)
        {
            System.Console.WriteLine($"{domainEvent.Client.FirstName} reached PREMIUM status.");
        }
    }
}
