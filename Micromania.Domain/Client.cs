using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Client : Entity
    {
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual Card Card { get; protected set; }

        private Client()
        {
        }

        private Client(string firstName, string lastName, Card card) 
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Card = card;
        }

        public static Client Create(string firstName, string lastName, Card card)
        {
            return new Client(firstName, lastName, card);
        }                

        public void BuyGame(Game game)
        {
            //Buying a game increases the number of points on your card
            Card.Points.Add(game.Points);     
        }
    }
}
