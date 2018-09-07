using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain.Mappings
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Id(x => x.Id);
            Map(x => x.Points);
            Map(x => x.Price);
            Map(x => x.Title);
        }
    }
}
