using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RapidApiCurrency.Models;

namespace RapidApiCurrency.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };

            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };

            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=GBP&to=TRY&amount=1"),
                Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request1))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CurrencyViewModel.Rootobject>(body);


                ViewBag.usd = values.result;


            }

            using (var response = await client.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CurrencyViewModel.Rootobject>(body);


                ViewBag.eur = values.result;


            }
            using (var response = await client.SendAsync(request3))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CurrencyViewModel.Rootobject>(body);


                ViewBag.gbp = values.result;




            }
            //Hava Durumu bilgisi için 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=istanbul&format=json&u=c"),
                Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.temperature = values.current_observation.condition.temperature;
            }

            var request5 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/timeseries?start_date=2023-12-06&end_date=2023-12-21&from=USD&to=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "e377acc97emsh8b49d7ff2f70369p1d60f2jsn2c2b95aa1ebb" },
        { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request5))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<HistoricalCurrencyViewModel>>(body);

                return View(values);
            }
       

        }

    }

}
