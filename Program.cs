using System;
using System.Collections.Generic;

namespace stock_purchase_dictionaries
{
    class Program
    {
        static void Main()
        {

            // A stock has a ticker symbol and a company name. Create a simple dictionary with ticker symbols and company names in the Main method.

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GE", "General Electric");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("APL", "Apple");
            stocks.Add("SMSG", "Samsung");

            // To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups
            string GE = stocks["GE"];

            // Next, create a list to hold stock purchases by an investor. The list will contain dictionaries.

            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>>();

            // Then add some purchases.
            // Example:

            purchases.Add (new Dictionary<string, double>(){ {"GE", 230.21} });
            purchases.Add (new Dictionary<string, double>(){ {"GE", 580.98} });
            purchases.Add (new Dictionary<string, double>(){ {"GE", 406.34} });
            purchases.Add (new Dictionary<string, double>(){ {"CAT", 206.34} });
            purchases.Add (new Dictionary<string, double>(){ {"CAT", 532.87} });
            purchases.Add (new Dictionary<string, double>(){ {"APL", 200.73} });
            purchases.Add (new Dictionary<string, double>(){ {"APL", 480.91} });
            purchases.Add (new Dictionary<string, double>(){ {"SMSG", 548.34} });
            purchases.Add (new Dictionary<string, double>(){ {"SMSG", 849.24} });

            // Console.WriteLine("Display Dictionaries");
            // foreach(Dictionary<string, double> purchaseDict in purchaseList) {
            //     Console.WriteLine("-------");
            //     foreach(KeyValuePair<string, double> kvp in purchaseDict) {
            //     Console.WriteLine($"key: {kvp.Key}, value: {kvp.Value}");
            //     }
            // }


            /*
                Define a new Dictionary to hold the aggregated purchase information.
                - The key should be a string that is the full company name.
                - The value will be the total valuation of each stock
            */

            Dictionary<string, double> stockReport = new Dictionary<string, double>();

            // Iterate over the purchases and record the valuation for each stock.

            foreach (Dictionary<string, double> purchase in purchases) {
                foreach (KeyValuePair<string, double> kvp in purchase)
                {
                    // Console.WriteLine($"Stock: {kvp}");
                    // Console.WriteLine("------");

                    // Does the full company name key already exist in the `stockReport`?

                    // Method #1
                    if (stockReport.ContainsKey(stocks[kvp.Key])) {
                        stockReport[stocks[kvp.Key]] += kvp.Value;
                    }
                    else {
                        stockReport[stocks[kvp.Key]] = kvp.Value;
                    }

                    // Method #2
                    // if (! stockReport.ContainsKey(kvp.Key)) {
                    //     stockReport.Add(kvp.Key, kvp.Value);
                    // }
                    // else {
                    //     // Method #1
                    //     // stockReport[stock.Key] += stock.Value;

                    //     // Method #2
                    //     double currentCost = stockReport[kvp.Key];
                    //     stockReport[kvp.Key] = currentCost + kvp.Value;
                    // }
                }
            }

            // Now that the report dictionary is populated, display the final results.

            foreach(KeyValuePair<string, double> item in stockReport)
            {
                Console.WriteLine($"The position in {item.Key} is worth {item.Value}");
            }
        }
    }
}
