using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture1
{
    internal class HomeWork
    {
        private decimal GetFullPrice(IEnumerable<string> destinations, IEnumerable<string> clients, IEnumerable<int> infantsIds,
            IEnumerable<int> childrenIds, IEnumerable<decimal> prices, IEnumerable<string> currencies)
        {
            try
            {
                if (!IsValide(destinations.Count(), clients.Count(), prices.Count(), currencies.Count())) 
                    throw new Exception("Invalide input");
            }
            catch
            {
                return default;
            }

            decimal[] deliveryPrices = new decimal[destinations.Count()];

            var pricesBuf       = prices.ToList();
            var destinationsBuf = destinations.Concat(new string[] { null }).ToArray();
            var currenciesBuf   = currencies.ToArray();

            int i = 0;
            foreach(var street in destinations)
            {
                deliveryPrices[i] = ConvertСurrency(currenciesBuf[i], 
                    GetNeighborsDiscount(street, destinationsBuf[i + 1]) 
                    * GetAgeDiscount(infantsIds, childrenIds, i) 
                    * (pricesBuf[i] + GetStreetDiscount(street))) ;

                i++;
            }
            return deliveryPrices.Sum();
        }

        bool IsValide(int destinationsCount, int clientsCount, int pricesCount, int currenciesCount)
        {
            if (destinationsCount != clientsCount
                || destinationsCount != pricesCount
                || destinationsCount != currenciesCount) 
                return false;

            return true;
        }

        decimal GetStreetDiscount(string street)
        {
            if (street.Contains("Wayne Street")) 
                return 10;
            if (street.Contains("North Heather Street"))
                return (decimal)-5.36;

            return 0;
        }

        decimal GetNeighborsDiscount(string street, string nextStreet)
        {
            if (nextStreet == null) 
                return 1;
            if (street.Split(' ')[1] == nextStreet.Split(' ')[1]) 
                return (decimal)0.85;

            return 1;
        }

        decimal GetAgeDiscount(IEnumerable<int> infantsIds, IEnumerable<int> childrenIds, int i)
        {
            if (infantsIds.Where(x => x == i).FirstOrDefault() != default) 
                return (decimal)0.5;
            if (childrenIds.Where(x => x == i).FirstOrDefault() != default) 
                return (decimal)0.75;

            return 1;
        }
        decimal ConvertСurrency(string currency, decimal price)
        {
            if (currency == "EUR") 
                return price*(decimal) 0.84;

            return price;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}