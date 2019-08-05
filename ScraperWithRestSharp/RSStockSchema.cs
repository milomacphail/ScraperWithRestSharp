using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperWithRestSharp
{
        public class RSStock
        {
            private System.DateTime _timeScraped;
            private string _stockSymbol;
            private string _lastPrice;
            private string _change;
            private string _changePercent;

            public System.DateTime TimeScraped { get => _timeScraped; set => _timeScraped = value; }
            public string StockSymbol { get => _stockSymbol; set => _stockSymbol = value; }
            public string LastPrice { get => _lastPrice; set => _lastPrice = value; }
            public string Change { get => _change; set => _change = value; }
            public string ChangePercent { get => _changePercent; set => _changePercent = value; }

            public RSStock(System.DateTime timeScraped, string stockSymbol, string lastPrice, string change, string changePercent)
            {
                this.TimeScraped = timeScraped;
                this.StockSymbol = stockSymbol;
                this.LastPrice = lastPrice;
                this.Change = change;
                this.ChangePercent = changePercent;
            }

        public void DisplayStockInfo()
        {
            Console.WriteLine("Time Scraped {0}", this.TimeScraped);
            Console.WriteLine("Stock Symbol: {0}", this.StockSymbol);
            Console.WriteLine("Latest Price: {0}", this.LastPrice);
            Console.WriteLine("Stock Price Change: {0}", this.Change);
            Console.WriteLine("Change Percent: {0}", this.ChangePercent);
        }

    }
       
     
}
