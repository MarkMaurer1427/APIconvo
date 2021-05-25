using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIconvo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var url1 = "https://api.kanye.rest/";
            var url2 = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";



            for (int i = 0; i < 6; i++)
            {
                var response1 = client.GetStringAsync(url1).Result;
                var kanyeQuote = JObject.Parse(response1).GetValue("quote").ToString();
                Console.WriteLine($"Kanye West: {kanyeQuote}");
                var response2 = client.GetStringAsync(url2).Result;
                var ronQuote = JArray.Parse(response2).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron Swanson: {ronQuote}");
            }

            
        }
    }
}
