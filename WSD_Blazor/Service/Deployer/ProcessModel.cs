namespace WSD_Blazor.Service.Deployer
{
    public class ProcessModel
    {
        public string Name { get; set; }

        public List<DeployableParams> DeployParametersList { get; set; }


        public ProcessModel(string name, List<DeployableParams> deployParametersList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeployParametersList = deployParametersList ?? throw new ArgumentNullException(nameof(deployParametersList));
        }

        public ProcessModel()
        {
            DeployParametersList = new List<DeployableParams>();
        }

        public class DeployableParams
        {
            public string Exe { get; set; }
            public string? Args { get; set; }

            public DeployableParams(string exe, string? args)
            {
                Exe = exe ?? throw new ArgumentNullException(nameof(exe));
                Args = args;
            }

            public DeployableParams() {  }
        }
    }
}
