using Micromania.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Purchase : AggregateRoot
    {
        public static readonly Purchase Uncharted = new Purchase("Uncharted", 15M);
        public static readonly Purchase Uncharted2 = new Purchase("Uncharted 2", 20M);
        public static readonly Purchase Uncharted4 = new Purchase("Uncharted 4", 59M);

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

        public Purchase()
        {
        }

        public Purchase(string title, decimal price)
        {
            Name = title;
            Price = price;
            Points = (int)Price * 10;
        }
    }
}
