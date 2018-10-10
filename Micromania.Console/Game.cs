using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Game : AggregateRoot
    {
        public static readonly Game Uncharted = new Game("Uncharted", 15M);
        public static readonly Game Uncharted2 = new Game("Uncharted 2", 20M);
        public static readonly Game Uncharted4 = new Game("Uncharted 4", 59M);

        public virtual string Title { get; protected set; }

        private decimal price;

        public virtual decimal Price
        {
            get { return price; }

            set
            {
                if (value <= 0 || value >= 100)
                    throw new InvalidOperationException("Invalid price.");
                    price = value;
            }
        }

        public virtual int Points { get; protected set; }

        protected Game()
        {
        }

        protected Game(string title, decimal price) : this()
        {
            Title = title;
            Price = price;
            Points = (int)Price * 10;           
        }
    }
}
