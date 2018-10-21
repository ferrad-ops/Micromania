using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Micromania.Console
{
    public class ClassicStatusReachedHandler : IHandler<ClassicStatusReached>
    {
        public ClassicStatusReachedHandler()
        {
        }

        public void Handle(ClassicStatusReached domainEvent)
        {           
            System.Console.WriteLine($"{domainEvent.Client.FirstName} reached CLASSIC status.");       
        }
    }
}
