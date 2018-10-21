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
        public static readonly Client Ferrad = new Client("Ferrad", "Rosé");
        public static readonly Client Mael = new Client("Mael", "LaRochelle");
        public static readonly Client Precieux = new Client("Précieux", "Rajiv");
        public static readonly Client Carmel = new Client("Carmel", "Taty");

        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual Status Status { get; protected set; }
        public virtual decimal MoneyInWallet { get; protected set; }
        public virtual IList<Purchase> Purchases { get; protected set; } = new List<Purchase>();
        public virtual int Points { get; protected set; }
        public virtual int QualifyingPurchases { get; protected set; }

        //private int pointsToDiscount;

        //public virtual int PointsToDiscount
        //{
        //    get { return pointsToDiscount; }

        //    set
        //    {
        //        pointsToDiscount = value;
        //    }
        //}

        protected Client()
        {
        }

        protected Client(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Status = Status.IsMegaCard;
        }

        //public static Client Create(string firstName, string lastName)
        //{
        //    return new Client(firstName, lastName);
        //}

        public virtual void AddMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Money.Ten, Money.TwentyFive, Money.Fifty, Money.Hundred
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInWallet += money.Amount;
        }

        public virtual void BuyGame(Game game)
        {
            if (game.Price > MoneyInWallet)
                throw new InvalidOperationException($"You don't have enough money");

            if (game.Price > 24)
                QualifyingPurchases++;

            var purchase = Purchase.Create(game);

            //Buying a game increases the number of points on your card
            Points += game.Points;

            UpgradeToClassic();

            //UpgradeToStar();

            //UpgradeToPremium();

            //PointsToDiscount = 2000 - Points;

            MoneyInWallet -= game.Price;

            Purchases.Add(purchase);
        }

        public virtual void UpgradeToClassic()
        {
            if (QualifyingPurchases >= 3)

                Status = Status.IsClassic;

            else if (QualifyingPurchases >= 6)

                Status = Status.IsStar;

            else if (QualifyingPurchases >= 9)

                Status = Status.IsPremium;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }

        public virtual void UpgradeToStar()
        {
            if (Status is Status.IsClassic && QualifyingPurchases >= 6)

                Status = Status.IsStar;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }

        public virtual void UpgradeToPremium()
        {
            if (Status is Status.IsStar && QualifyingPurchases >= 9)

                Status = Status.IsPremium;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }
    }

    public enum Status
    {
        IsMegaCard,
        IsClassic,
        IsStar,
        IsPremium
    }
}
