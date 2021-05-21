using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services.ApplesService
{
    public interface IApplesService
    {
        event Action OnChange;

        int Apples { get; set; }

        void EatApples(int amount);

        void AddApples(int amount);
    }
}
