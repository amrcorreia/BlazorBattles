using BlazorBattles.Shared;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _httpClient;
        private readonly IBananaService _bananaService;

        public UnitService(IToastService toastService,
            HttpClient httpClient,
            IBananaService bananaService)
        {
            _toastService = toastService;
            _httpClient = httpClient;
            _bananaService = bananaService;
        }

        public IList<Unit> Units { get; set; } = new List<Unit>();

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();

        public async Task AddUnit(int unitId)
        {
            Unit unit = Units.First(unit => unit.Id == unitId);
            var result = await _httpClient.PostAsJsonAsync<int>("api/UserUnit", unitId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                await _bananaService.GetBananas();
                _toastService.ShowSuccess($"You {unit.Title} has been built!", "Unit built!");
            }            
        }

        public async Task LoadUnitsAsync()
        {
            if (Units.Count == 0)
            {
                Units = await _httpClient.GetFromJsonAsync<IList<Unit>>("api/unit");
            }
        }
    }
}
