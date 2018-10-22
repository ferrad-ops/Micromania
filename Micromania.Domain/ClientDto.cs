using System.Collections.Generic;

namespace Micromania.Domain
{
    public class ClientDto
    {        
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Status Status { get; private set; }
        public decimal MoneyInWallet { get; private set; }
        public IList<Purchase> Purchases { get; private set; } = new List<Purchase>();
        public int Points { get; private set; }
        public int QualifyingPurchases { get; protected set; }

        public ClientDto(string firstName, string lastName)            
        {
            FirstName = firstName;
            LastName = lastName;
            Status = Status.MegaCard;
        }
    }
}