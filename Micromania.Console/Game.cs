using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Game : Entity
    {
        public virtual string Title { get; protected set; }
        public virtual decimal Price { get; protected set; }
        public virtual Points Points { get; protected set; }

        public Game(Points points)
        {
            Points = points;
        }
    }
}
