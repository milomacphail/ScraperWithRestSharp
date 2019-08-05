using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperWithRestSharp
{   class CallData
    {
        private List<string> stocks;
        private List<RSStock> stockList;

        public List<string> Stocks { get => stocks; set => stocks = value; }
        internal List<RSStock> StockList { get => stockList; set => stockList = value; }

        public CallData()
        {
            this.Stocks = new List<string>();
            this.StockList = new List<RSStock>();
        }
    }
}
