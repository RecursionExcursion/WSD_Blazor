using System.Diagnostics;

namespace WSD_Blazor.Service.Deployer
{
    public class ProcessExecutor
    {
        public List<Process> Processes { get; } = new List<Process>();

        public void AddUrlProcess(string url) => Processes.Add(CreateProcess(url, null));

        public void AddExeProcess(string exe, string filePath) => Processes.Add(CreateProcess(exe, filePath));

        public async void ExecuteProcesses()
        {
            await DeployProcessesWithAwait();
        }

        private async Task DeployProcessesWithAwait()
        {
            foreach (var p in Processes)
            {
                using (p)
                {
                    p.Start();
                }
                await Task.Delay(1000);
            }
        }

        private static Process CreateProcess(string fileName, string? args)
        {
            try
            {
                Process newProcess = new Process();
                newProcess.StartInfo.UseShellExecute = true;

                newProcess.StartInfo.FileName = fileName;

                if (args != null)
                {
                    newProcess.StartInfo.Arguments = args;
                }
                return newProcess;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
        }
    }
}
