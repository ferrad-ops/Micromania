using System;
using System.Collections.Generic;

namespace Micromania.Console
{
    public class Card : Entity
    {       
        public virtual CardType CardType { get; protected set; }
        public virtual Points Points { get; set; } 
        //public virtual Client Client { get; protected set; }

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
    }

    public enum CardType
    {
        Classic,        
        Premium,
        Gold,
        Platinium
    }
}