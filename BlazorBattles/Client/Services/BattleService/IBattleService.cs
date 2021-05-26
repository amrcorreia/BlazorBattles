using BlazorBattles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services.BattleService
{
    public interface IBattleService
    {
        Task<BattleResult> StartBattle(int opponentId);
    }
}
