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
        public static readonly Client Ferrad = Create("Ferrad", "Makosso");

        public virtual string FirstName { get;  set; }
        public virtual string LastName { get;  set; }
        public virtual decimal Bonus { get; protected set; }
        public virtual decimal MoneyInWallet { get; protected set; }
        public virtual Status Status { get; protected set; }
        public virtual IList<Purchase> Purchases { get; protected set; }
        public virtual int Points { get; protected set; }
        public virtual int QualifyingPurchases { get; protected set; }

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
                if (Bonus == 0)
                    Bonus += 10;
                if (Bonus == 10)
                    return;
            }

            while (Points >= 8000)
            {
                if (Bonus == 10)
                    Bonus += 10;
                if (Bonus == 20)
                    return;
            }            
        }

        public virtual void UpgradeToClassic()
        {
            if (QualifyingPurchases >= 3)

                Status = Status.Classic;
        }

        public virtual void UpgradeToStar()
        {
            if (Status is Status.Classic && QualifyingPurchases >= 6)

                Status = Status.Star;
        }

        public virtual void UpgradeToPremium()
        {
            if (Status is Status.Star && QualifyingPurchases >= 9)

                Status = Status.Premium;
        }

        public virtual string CanAddBonusToWallet()
        {
            if (Bonus <= 0)
                return "Vous n'avez pas assez en bon d'achat";
            return string.Empty;
        }

        public virtual void AddBonusToWallet()
        {
            CanAddBonusToWallet();
            MoneyInWallet += Bonus;
            Bonus -= Bonus;
            Clear();
        }

        public virtual string CanUseBonus(Game game)
        {
            if (game == null)
                return "Veuillez choisir un jeu";
            if (game.Price > Bonus)
                return "Pas assez en bon d'achat";

            return string.Empty;
        }

        public virtual void UseBonus(Game game)
        {
            if (CanUseBonus(game) != string.Empty)
                throw new InvalidOperationException();

            BuyGame(game);

            var purchase = Purchase.Create(game);

            Bonus -= game.Price;

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
