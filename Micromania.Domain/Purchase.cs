using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Purchase : Entity
    {
        public virtual double Cost { get; protected set; }
        public virtual DateTime PurchaseDate { get; protected set; }
        public virtual string Game { get; protected set; }

        public Purchase()
        {
        }

        public Purchase(Game game)
        {
            Cost = game.Price;
            PurchaseDate = DateTime.Now;
            Game = game.Name;
        }

        public static Purchase Create(Game game)
        {
            return new Purchase(game);
        }        
    }
}
