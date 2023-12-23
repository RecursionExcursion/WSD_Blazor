namespace WSD_Blazor.Service.Deployer
{
    public static class ProcessManager
    { 
        public static void ExecuteProcesses(DeploymentOrder processes)
        {
            ProcessExecutor executor = new();

            foreach (var p in processes.DeploymentParameters)
            {
                if (p.Type == ProcessType.Url)
                {
                    executor.AddUrlProcess(p.Exe);
                }
                else if(p.Type == ProcessType.Exe)
                {
                    executor.AddExeProcess(p.Exe, p.Args);

                }
            }
            executor.ExecuteProcesses();
        }
    }
}
