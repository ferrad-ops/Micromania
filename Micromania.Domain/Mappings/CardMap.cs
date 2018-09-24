using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain.Mappings
{
    public class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Id(x => x.Id);
            //HasMany(x => x.Points).Inverse().Cascade.All();
            Map(x => x.CardType);
        }
    }
}
