using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        private readonly HttpClient _http;

        public BananaService(HttpClient http)
        {
            _http = http;
        }
        
        public int Bananas { get; set; } = 0;

        public event Action OnChange;

        public void AddBananas(int amount)
        {
            Bananas += amount;
            BananasChanged();
        }

        public void EatBananas(int amount)
        {
            Bananas -= amount;
            BananasChanged();
        }

        public async Task GetBananas()
        {
            Bananas = await _http.GetFromJsonAsync<int>("api/User/GetBananas");
            BananasChanged();
        }

        void BananasChanged() => OnChange.Invoke();
    }
}
