using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Razor.DTO
{
    public record ProcessCreationDTO(
        DeployableProcesses.DeployableParams DeployableParam,
        List<DeployableProcesses.DeployableParams>? Params
        );
}
