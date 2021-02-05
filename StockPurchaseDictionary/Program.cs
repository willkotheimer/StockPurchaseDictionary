using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("APPL", "Apple");
            stocks.Add("AMZN", "Amazon");
            stocks.Add("GE", "General Electric");

            // Add a few more of your favorite stocks


            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();


            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "CAT", shares: 32, price: 17.87));
            purchases.Add((ticker: "APPL", shares: 80, price: 19.02));
            purchases.Add((ticker: "AMZN", shares: 10, price: 3500));
            purchases.Add((ticker: "AMZN", shares: 12, price: 3500));
            // Add more for each stock you added to the stocks dictionary

            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.

            /*
             * Define a new Dictionary to hold the aggregated purchase information. - The key should be a string that is the full company name.
             * The value will be the valuation of each stock (price*amount) { "General Electric": 35900, "AAPL": 8445, ... }
            */

            Dictionary<string, double> owned = new Dictionary<string, double>();
            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                // Does the company name key already exist in the report dictionary?
                // If it does, update the total valuation
                // If not, add the new key and set its value
                if (!owned.ContainsKey(stocks[purchase.ticker]))
                {
                    double amt = purchase.shares * purchase.price;
                    owned.Add(stocks[purchase.ticker], amt);
                } else
                {
                    double newAmount = owned[stocks[purchase.ticker]] + purchase.shares * purchase.price;
                    owned[stocks[purchase.ticker]] = newAmount;
                }


            }
            foreach(var (key, value) in owned)
            {
                Console.WriteLine($"{key}:{value}");
            }


        }
    }

}