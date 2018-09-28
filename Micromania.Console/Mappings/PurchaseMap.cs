using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console.Mappings
{
    public class PurchaseMap : ClassMap<Purchase>
    {
        public PurchaseMap()
        {
            Id(x => x.Id);
            Map(x => x.Cost);
            Map(x => x.Game);
            Map(x => x.PurchaseDate);
        }
    }
}
