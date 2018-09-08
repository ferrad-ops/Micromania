using System;
using System.Collections.Generic;

namespace Micromania.Console
{
    public class Card : Entity
    {       
        public virtual CardType CardType { get; protected set; }
        public virtual Points Points { get; protected set; } 

        private Card()
        {            
        }

        private Card(CardType cardType, Points points) : this()
        {
            CardType = cardType;
            Points = points;
        }        

        public static Card Create(CardType cardType, Points points)
        {
            return new Card(cardType, points);
        }        
        
        public void UseCardPoints()
        {
            Points.UsePoints();
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