using Microsoft.AspNetCore.Components;
using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Razor.DTO
{
    public record ProcessListDTO(DeployableProcesses Model, bool IsNewModel, string? InitialKey);
}
