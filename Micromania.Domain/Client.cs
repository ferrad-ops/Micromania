using Micromania.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Client : AggregateRoot
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual Card Card { get; protected set; }
        public virtual int Points { get; protected set; }
        public virtual CardType CardType { get; protected set; }
        public virtual IList<Purchase> Purchases { get; protected set; } = new List<Purchase>();
        private int pointsToDiscount;

        public virtual int PointsToDiscount
        {
            get { return pointsToDiscount; }

            set
            {
                if (value < 0 || value > 2000)
                    throw new InvalidOperationException("Invalid value");
                pointsToDiscount = value;
            }
        }

        protected Client()
        {
        }

        private Client(string firstName, string lastName, Card card)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Card = card;
            CardType = Card.CardType;
        }

        public static Client Create(string firstName, string lastName, Card card)
        {
            return new Client(firstName, lastName, card);
        }

        public virtual void BuyGame(Game game)
        {
            var purchase = Purchase.Create(game.Price);

            //Buying a game increases the number of points on your card
            Card.AddGamePoints(game);

            Points = Card.Points;

            PointsToDiscount = 2000 - Points;

            Purchases.Add(purchase);
        }

        public virtual void BuyGameWithPoints(Game game)
        {
            Card.UseCardPoints();
        }
    }
}
