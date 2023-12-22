namespace WSD_Blazor.Service.Deployer
{
    public static class ProcessManager
    { 
        public static void ExecuteProcesses(DeployableProcesses processes)
        {
            ProcessExecutor executor = new();

            foreach (var p in processes.DeployParametersList)
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
