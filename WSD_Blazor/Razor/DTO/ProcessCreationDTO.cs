using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Razor.DTO
{
    public record ProcessCreationDTO(DeploymentParams DeployableParam, List<DeploymentParams>? Params);
}
