using lab1.Entities;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab1.Services;

public class RateService : IRateService
{
    HttpClient _httpClient;
    public RateService(HttpClient httpClient) 
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Rate>?> GetRates(DateTime date)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            var baseUri = new Uri("https://api.nbrb.by/exrates/rates");
            var response = await _httpClient.GetAsync(baseUri + $"?ondate={date.Year}-{date.Month}-{date.Day}&periodicity=0");
            var list = await JsonSerializer.DeserializeAsync<List<Rate>>(await response.Content.ReadAsStreamAsync());
            var listRates = new List<Rate>();
            foreach (var rate in list)
            {
                if (rate.Cur_Abbreviation == "RUB" || rate.Cur_Abbreviation == "EUR" || rate.Cur_Abbreviation == "USD" 
                    || rate.Cur_Abbreviation == "CHF" || rate.Cur_Abbreviation == "CNY" || rate.Cur_Abbreviation == "GBP")
                {
                    listRates.Add(rate);
                }
            }
            return listRates;
        } 
        else
        {
            return null;
        }
    }
}
