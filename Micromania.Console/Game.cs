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

        public Game()
        {
        }

        public Game(string title, decimal price)
        {
            Title = title;
            Price = price;
            Points = (int)Price * 10;           
        }
    }
}
