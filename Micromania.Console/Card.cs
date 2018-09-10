using System;
using System.Collections.Generic;

namespace Micromania.Console
{
    public class Card : Entity
    {       
        public virtual CardType CardType { get; protected set; }
        public virtual int Points { get; protected set; } = 0;

        private Card()
        {            
        }

        private Card(CardType cardType) : this()
        {
            CardType = cardType;            
        }        

        public static Card Create(CardType cardType)
        {
            return new Card(cardType);
        }        
        
        public void UseCardPoints()
        {
            if (Points >= 2000)
                Points -= 2000;
            else
                throw new InvalidOperationException("You need a minimum of 2000 points to use them.");
        }

        public void AddGamePoints(Game game)
        {
            Points += game.Points;            
        }        
    }

    public enum CardType
    {
        Classic,
        Star,
        Premium       
    }
}