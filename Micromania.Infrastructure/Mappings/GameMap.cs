using FluentNHibernate.Mapping;
using Micromania.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Infrastructure.Mappings
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Id(x => x.Id);
            Map(x => x.Points);
            Map(x => x.Price);
            Map(x => x.Name);
        }
    }
}
