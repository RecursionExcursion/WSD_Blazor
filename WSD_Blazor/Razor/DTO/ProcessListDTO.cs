using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Razor.DTO
{
    public record ProcessListDTO(DeploymentOrder Order, bool IsNewModel, string? InitialKey);
}
