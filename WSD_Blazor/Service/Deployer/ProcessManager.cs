namespace WSD_Blazor.Service.Deployer
{
    public static class ProcessManager
    { 
        public static void ExecuteProcesses(ProcessModel model)
        {
            ProcessExecutor executor = new ProcessExecutor();

            foreach (var p in model.DeployParametersList)
            {
                if (p.Args == null)
                {
                    executor.AddUrlProcess(p.Exe);
                }
                else
                {
                    executor.AddExeProcess(p.Exe, p.Args);

                }
            }
            executor.ExecuteProcesses();
        }
    }
}
