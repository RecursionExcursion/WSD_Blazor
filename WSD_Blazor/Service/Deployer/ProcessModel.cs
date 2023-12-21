namespace WSD_Blazor.Service.Deployer
{
    public class ProcessModel
    {
        public string Name { get; set; }

        public List<DeployableParam> DeployParametersList { get; set; }


        public ProcessModel(string name, List<DeployableParam> deployParametersList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeployParametersList = deployParametersList ?? throw new ArgumentNullException(nameof(deployParametersList));
        }

        public ProcessModel()
        {
            DeployParametersList = new List<DeployableParam>();
            Name = "";
        }

        public class DeployableParam
        {
            public string Exe { get; set; } = "";
            public string? Args { get; set; }
            public ProcessType Type { get; set; }

            public DeployableParam(string exe, string? args)
            {
                Exe = exe ?? throw new ArgumentNullException(nameof(exe));
                Args = args;
            }

            public DeployableParam() {  }
        }
    }
}
