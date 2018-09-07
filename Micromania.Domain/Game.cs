using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Game : Entity
    {
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Points { get; set; }

        public Game(int points)
        {
            Points = points;
        }
    }
}
