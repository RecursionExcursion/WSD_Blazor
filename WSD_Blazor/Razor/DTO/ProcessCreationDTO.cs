using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Razor.DTO
{
    public record ProcessCreationDTO(
        ProcessModel.DeployableParam DeployableParam,
        List<ProcessModel.DeployableParam>? Params
        );
}
