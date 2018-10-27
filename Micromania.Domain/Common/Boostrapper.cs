using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Micromania.Domain;

namespace Micromania.Domain.Common
{
    public static class Boostrapper 
    {
        public static void Initialize()
        {
            DomainEvents.Init();
        }
    }
}
