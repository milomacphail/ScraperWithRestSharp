using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace ScraperWithRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://morning-star.p.rapidapi.com/market/get-summary");

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Host", "morning-star.p.rapidapi.com");
            request.AddHeader("X-RapidAPI-Key", "766253babbmsh7dc7313fc6fb941p1f3b2fjsn3e5e1b4f90ba");
            request.AddHeader("content-type", "application/json");

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            //Console.WriteLine(content);

            dynamic JsonObject = JsonConvert.DeserializeObject(content);

            //Console.WriteLine(JsonObject[0]["Exchange"]);

            //Console.WriteLine(JsonObject["MarketRegions"]["USA"]);

            JArray USAStocks = JsonObject["MarketRegions"]["USA"];

            string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestSharpTable;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection dbConnection = new SqlConnection(connection))
            {
                dbConnection.Open();
                Console.WriteLine("Database Open");

                foreach (JToken stock in USAStocks)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT into dbo.RestSharpTable (TimeScraped, Symbol, LastPrice, Change, ChangePercent) VALUES (@time_scraped, @symbol, @last_price, @change, @change_percent)", dbConnection);

                    insertCommand.Parameters.AddWithValue("@time_scraped", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@symbol", stock["RegionAndTicker"].ToString());
                    insertCommand.Parameters.AddWithValue("@last_price", stock["Price"].ToString());
                    insertCommand.Parameters.AddWithValue("@change", stock["PriceChange"].ToString());
                    insertCommand.Parameters.AddWithValue("@change_percent", stock["PercentChange"].ToString());

                    insertCommand.ExecuteNonQuery();
                }

                Console.WriteLine("Database Updated");
                dbConnection.Close();
            }

            /*foreach (JToken stock in dataAsJArray)
            {
                Console.WriteLine(stock["Name"]);
                Console.WriteLine(stock["TypeName"]);
                Console.WriteLine(stock["");
            }*/

            /*foreach (JToken stock in dataAsJArray)
            {
                Console.WriteLine();
            }*/

        }

    }
}
       /* public class GetAPIData
        {
            public static void RestScrape(CallData scrape) {

             
                
                

            }


        }

    }
}
*/