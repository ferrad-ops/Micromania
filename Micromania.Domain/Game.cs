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
        public static readonly Game CBC = new Game("Crash Bandicoot", 10M);
        public static readonly Game Uncharted = new Game("Uncharted", 15M);
        public static readonly Game Uncharted2 = new Game("Uncharted 2", 20M);
        public static readonly Game Uncharted4 = new Game("Uncharted 4", 59M);
        public static readonly Game MGS = new Game("Metal Gear Solid 4", 25M);
        public static readonly Game GOW = new Game("God Of War", 35M);

        public virtual string Name { get; protected set; }
        public virtual decimal Price { get; protected set; }
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
