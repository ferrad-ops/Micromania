using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Domain
{
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0);
        public static readonly Money Ten = new Money(1, 0, 0, 0);
        public static readonly Money TwentyFive = new Money(0, 1, 0, 0);
        public static readonly Money Fifty = new Money(0, 0, 1, 0);
        public static readonly Money Hundred = new Money(0, 0, 0, 1);

        public int TenEuros { get; }
        public int TwentyFiveEuros { get; }
        public int FiftyEuros { get; }
        public int OneHundredEuros { get; }

        public decimal Amount =>
            TenEuros * 10 +
            TwentyFiveEuros * 25 +
            FiftyEuros * 50 +
            OneHundredEuros * 100;

        public Money()
        {
        }

        public Money(int tenEuros, int twentyFiveEuros, int fiftyEuros, int oneHundredEuros)
        {
            if (tenEuros < 0)
                throw new InvalidOperationException();
            if (twentyFiveEuros < 0)
                throw new InvalidOperationException();
            if (fiftyEuros < 0)
                throw new InvalidOperationException();
            if (oneHundredEuros < 0)
                throw new InvalidOperationException();

            TenEuros = tenEuros;
            TwentyFiveEuros = twentyFiveEuros;
            FiftyEuros = fiftyEuros;
            OneHundredEuros = oneHundredEuros;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.TenEuros + money2.TenEuros,
                money1.TwentyFiveEuros + money2.TwentyFiveEuros,
                money1.FiftyEuros + money2.FiftyEuros,
                money1.OneHundredEuros + money2.OneHundredEuros);

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.TenEuros - money2.TenEuros,
                money1.TwentyFiveEuros - money2.TwentyFiveEuros,
                money1.FiftyEuros - money2.FiftyEuros,
                money1.OneHundredEuros - money2.OneHundredEuros);
        }

        protected override bool EqualsCore(Money other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
