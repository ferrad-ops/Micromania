using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Purchase : Entity
    {
        public virtual decimal Cost { get; protected set; }
        public virtual DateTime PurchaseDate { get; protected set; }
        public virtual string Game { get; protected set; }

        public Purchase()
        {
        }

        public Purchase(Purchase game)
        {
            Cost = game.Price;
            PurchaseDate = DateTime.Now;
            Game = game.Name;
        }

        public static Purchase Create(Purchase game)
        {
            return new Purchase(game);
        }        
    }
}
