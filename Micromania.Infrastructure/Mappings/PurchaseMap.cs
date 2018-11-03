using FluentNHibernate.Mapping;
using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Infrastructure.Mappings
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
