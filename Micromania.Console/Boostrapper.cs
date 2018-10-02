using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaySmith.DomainEvents.StructureMap;

namespace Micromania.Console
{
    public static class Boostrapper 
    {
        public static void Initialize()
        {
            DomainEvents.Init();
        }

    }
}
