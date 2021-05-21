using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services.ApplesService
{
    public class ApplesService : IApplesService
    {
        public int Apples { get; set; } = 7;

        public event Action OnChange;

        public void AddApples(int amount)
        {
            Apples += amount;
            ApplesChanged();
        }

        public void EatApples(int amount)
        {
            Apples -= amount;
            ApplesChanged();
        }

        void ApplesChanged() => OnChange.Invoke();
    }
}
