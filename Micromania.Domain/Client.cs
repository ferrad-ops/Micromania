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
        public virtual decimal GiftVoucher { get; protected set; }
        public virtual decimal MoneyInWallet { get; protected set; }
        public virtual Status Status { get; protected set; }
        public virtual IList<Purchase> Purchases { get; protected set; }
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
            Purchases = new List<Purchase>();
            Status = Status.MegaCard;            
        }

        public static Client Create(string firstName, string lastName)
        {
            return new Client(firstName, lastName);
        }

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

        public virtual string CanBuyGame(Game game)
        {
            if (game == null)
                return "Veuillez choisir un jeu";
            if (game.Price > MoneyInWallet)
                return "Vous n'avez pas assez d'argent";

            return string.Empty;
        }

        public virtual void BuyGame(Game game)
        {
            if (CanBuyGame(game) != string.Empty)
                throw new InvalidOperationException();

            if (game.Price > MoneyInWallet)
                throw new InvalidOperationException();

            if (game.Price > 24)
                QualifyingPurchases++;
            
            var purchase = Purchase.Create(game);

            //Buying a game increases the number of points on your card
            Points += game.Points;

            UpgradeToClassic();

            UpgradeToStar();

            UpgradeToPremium();

            MoneyInWallet -= game.Price;

            Purchases.Add(purchase);

            while (Points >= 2000 && Points < 8000)
            {
                if (GiftVoucher == 0)
                    GiftVoucher += 10;
                if (GiftVoucher == 10)
                    return;
            }

            while (Points >= 8000)
            {
                if (GiftVoucher == 10)
                    GiftVoucher += 10;
                if (GiftVoucher == 20)
                    return;
            }            
        }

        public virtual void UpgradeToClassic()
        {
            if (QualifyingPurchases >= 3)

                Status = Status.Classic;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }

        public virtual void UpgradeToStar()
        {
            if (Status is Status.Classic && QualifyingPurchases >= 6)

                Status = Status.Star;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }

        public virtual void UpgradeToPremium()
        {
            if (Status is Status.Star && QualifyingPurchases >= 9)

                Status = Status.Premium;

            DomainEvents.Raise(new ClientStatusChanged() { Client = this });
        }

        public virtual string CanUseGiftVoucher(Game game)
        {
            if (game == null)
                return "Veuillez choisir un jeu";
            if (game.Price > GiftVoucher)
                return "Pas assez en bon d'achat";

            return string.Empty;
        }

        public virtual void UseGiftVoucher(Game game)
        {
            if (CanUseGiftVoucher(game) != string.Empty)
                throw new InvalidOperationException();

            BuyGame(game);

            var purchase = Purchase.Create(game);

            GiftVoucher -= game.Price;

            Clear();
        }

        public virtual void Clear()
        {
            Points = 0;
        }
    }

    public enum Status
    {
        MegaCard,
        Classic,
        Star,
        Premium
    }
}
