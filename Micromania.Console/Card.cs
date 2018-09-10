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