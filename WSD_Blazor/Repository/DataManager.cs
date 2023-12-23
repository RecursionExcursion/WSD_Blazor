using WSD_Blazor.Data;
using WSD_Blazor.Repository.State;
using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Repository
{
    public class DataManager
    {
        private static readonly Serializer serializer = Serializer.Instance;

        private static readonly Lazy<DataManager> lazyInstance = new(() => new DataManager());

        public static DataManager Instance => lazyInstance.Value;

        public AppState State { get; set; } = serializer.LoadData() ?? new();

        private DataManager() { }

        public void AddNewProcess(DeploymentOrder model)
        {
            if (State.DeploymentOrderMap.TryAdd(model.Name, model))
            {
                SyncData();
            }
        }

        public DeploymentOrder GetProcessByName(string name) => State.DeploymentOrderMap[name];

        public void RemoveProcess(DeploymentOrder model)
        {
            if (model != null)
            {
                State.DeploymentOrderMap.Remove(model.Name);
                SyncData();
            }
        }

        public void UpdateProcess(DeploymentOrder model)
        {
            if (State.DeploymentOrderMap.ContainsKey(model.Name))
            {
                State.DeploymentOrderMap[model.Name] = model;
            }
            SyncData();
        }

        public void UpdateProcess(string intialKey, DeploymentOrder newModel)
        {
            if (!string.Equals(intialKey, newModel.Name))
            {
                State.DeploymentOrderMap.Remove(intialKey);
            }
            State.DeploymentOrderMap[newModel.Name] = newModel;
            SyncData();
        }


        public void AddExecutable(string name, string path)
        {
            State.Executables.Add(new(name, path));
        }

        public void DeleteExecutable(Executable exe)
        {
            State.Executables.Remove(exe);
            SyncData();
        }

        public void SyncData() => SaveToFile();

        private void LoadFromFile() => State = serializer.LoadData() ?? new AppState();

        private void SaveToFile() => serializer.SaveData(State);
    }
}
