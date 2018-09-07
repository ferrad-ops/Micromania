using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Game : Entity
    {
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Points Points { get; set; }

        public Game(Points points)
        {
            Points = points;
        }
    }
}
