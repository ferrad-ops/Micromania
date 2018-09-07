using System.Collections.Generic;

namespace Micromania.Console
{
    public class Store : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual IList<Game> Games { get; protected set; }
    }
}
