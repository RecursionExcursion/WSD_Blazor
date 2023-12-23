namespace WSD_Blazor.Service.Deployer
{
    public class DeploymentOrder
    {
        public string Name { get; set; }

        public List<DeploymentParams> DeploymentParameters { get; set; }


        public DeploymentOrder(string name, List<DeploymentParams> deployParametersList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeploymentParameters = deployParametersList ?? throw new ArgumentNullException(nameof(deployParametersList));
        }

        public DeploymentOrder()
        {
            DeploymentParameters = new List<DeploymentParams>();
            Name = string.Empty;
        }

        public DeploymentOrder DeepCopy()
        {
            DeploymentOrder copy = new()
            {
                Name = Name
            };

            foreach (var param in DeploymentParameters)
            {
                DeploymentParams paramCopy = param.DeepCopy();
                copy.DeploymentParameters.Add(paramCopy);
            }
            return copy;
        }
    }
}
