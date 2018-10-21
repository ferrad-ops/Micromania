using Micromania.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Game : AggregateRoot
    {
        public static readonly Game Uncharted = new Game("Uncharted", 15M);
        public static readonly Game Uncharted2 = new Game("Uncharted 2", 20M);
        public static readonly Game Uncharted4 = new Game("Uncharted 4", 59M);

        public virtual string Name { get; protected set; }

        private decimal price;

        public virtual decimal Price
        {
            get { return price; }

            set
            { 
                price = value;
            }
        }

        public virtual int Points { get; protected set; }

        public Game()
        {
        }

        public Game(string title, decimal price)
        {
            Name = title;
            Price = price;
            Points = (int)Price * 10;
        }
    }
}
