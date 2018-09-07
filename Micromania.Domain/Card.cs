using System;
using System.Collections.Generic;

namespace Micromania.Domain
{
    public class Card : Entity
    {
        //public long Id { get; set; }
        public virtual CardType CardType { get; protected set; }
        public virtual IList<int> Points { get; protected set; } 

        private Card()
        {            
        }

        private Card(CardType cardType, IList<int> points) : this()
        {
            CardType = cardType;
            Points = points;
        }        

        public static Card Create(CardType cardType, IList<int> points)
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