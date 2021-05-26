﻿using BlazorBattles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services.UnitService
{
    public interface IUnitService
    {
        IList<Unit> Units { get; set;  }
        
        IList<UserUnit> MyUnits { get; set; }

        Task AddUnit(int unitId);

        Task LoadUnitsAsync();
    }
}
