namespace WSD_Blazor.Service.Deployer
{
    public class DeploymentParams
    {
        public string Exe { get; set; } = "";
        public string? Args { get; set; }
        public ProcessType Type { get; set; }

        public DeploymentParams(string exe, string? args)
        {
            Exe = exe ?? throw new ArgumentNullException(nameof(exe));
            Args = args;
        }

        public DeploymentParams() { }

        public DeploymentParams DeepCopy()
        {
            return new DeploymentParams(Exe, Args)
            {
                Type = Type
            };
        }
    }
}
