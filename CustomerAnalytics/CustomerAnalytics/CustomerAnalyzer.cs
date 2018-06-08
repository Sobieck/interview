﻿using System.Collections.Generic;
using System.Linq;

namespace CustomerAnalytics
{
    public class CustomerAnalyzer
    {
        public int GetCountTheNumberOfPeopleOverAnAge(ICollection<Customer> customers, uint ageLimit)
        {
            return customers.Count(x => x.Age > ageLimit);
        }

        public Customer GetNewestCustomerWhoIsStillActive(ICollection<Customer> customers)
        {
            return customers.OrderByDescending(x => x.Registered).FirstOrDefault(x => x.IsActive);
        }

        public ICollection<FavoriteFruitFrequency> CountOfEachFavoriteFruit(ICollection<Customer> customers)
        {
            return customers
                .GroupBy(x => x.FavoriteFruit)
                .Select(x => new FavoriteFruitFrequency { Count = x.Count(), FavoriteFruit = x.Key })
                .ToList();
        }

        public string MostCommonEyeColor(ICollection<Customer> customers)
        {
            if (customers.Count == 0)
            {
                return null;
            }

            return customers
                .GroupBy(x => x.EyeColor)
                .OrderByDescending(x => x.Count())
                .First()
                .First()
                .EyeColor;
        }

        public decimal CalculateTotalBalance(List<Customer> customers)
        {
            return customers.Sum(x => x.Balance);
        }

        public string GetUsersFullName(List<Customer> customers, string id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return null;
            }

            return $"{customer.Name.Last}, {customer.Name.First}";
        }
    }
}
