﻿using WSD_Blazor.Repository.State;
using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Repository
{
    public  class AppState
    {
        public List<Executable> Executables { get; set; } = new();
        public Dictionary<string, ProcessModel> ProcessModels { get; set; } = new();
    }
}
