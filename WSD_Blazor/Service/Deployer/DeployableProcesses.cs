namespace WSD_Blazor.Service.Deployer
{
    public class DeployableProcesses
    {
        public string Name { get; set; }

        public List<DeployableParams> DeployParametersList { get; set; }


        public DeployableProcesses(string name, List<DeployableParams> deployParametersList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeployParametersList = deployParametersList ?? throw new ArgumentNullException(nameof(deployParametersList));
        }

        public DeployableProcesses()
        {
            DeployParametersList = new List<DeployableParams>();
            Name = "";
        }

        public class DeployableParams
        {
            public string Exe { get; set; } = "";
            public string? Args { get; set; }
            public ProcessType Type { get; set; }

            public DeployableParams(string exe, string? args)
            {
                Exe = exe ?? throw new ArgumentNullException(nameof(exe));
                Args = args;
            }

            public DeployableParams() {  }
        }
    }
}
