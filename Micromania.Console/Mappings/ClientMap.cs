using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console.Mappings
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Status);
            Map(x => x.Points);
            Map(x => x.PointsToDiscount);
            HasMany(x => x.Purchases).Cascade.All();
        }
    }
}
