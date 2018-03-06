using System;
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Core
{
    public enum CurrencyUnit 
    {
        EUR,
        GBP,
        USD
    }

    public class Money
    {
        public CurrencyUnit CurrencyUnit;
        public decimal Amount;

        public Money(CurrencyUnit currencyUnit, decimal amount)
        {
            this.CurrencyUnit = currencyUnit;
            this.Amount = amount;
        }

        public Money Plus(Money toAdd)
        {
            if (toAdd.CurrencyUnit != this.CurrencyUnit)
            {
                throw new ArgumentException("Cannot add money from different currencies");
            }

            return new Money(CurrencyUnit, toAdd.Amount + Amount);
        }

        public static Money Zero(CurrencyUnit currencyUnit)
        {
            return new Money(currencyUnit, 0);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Money;

            if (item == null)
            {
                return false;
            }

            return CurrencyUnit.Equals(item.CurrencyUnit) && Amount.Equals(item.Amount);
        }
    }
}
