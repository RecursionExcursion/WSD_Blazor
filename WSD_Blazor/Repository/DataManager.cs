using System.Reflection;
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

        public void AddNewProcess(ProcessModel model)
        {
            if (State.ProcessModels.TryAdd(model.Name, model))
            {
                SyncData();
            }
        }

        public ProcessModel GetProcessByName(string name) => State.ProcessModels[name];

        public void RemoveProcess(ProcessModel model)
        {
            if (model != null)
            {
                State.ProcessModels.Remove(model.Name);
                SyncData();
            }
        }

        public void UpdateProcess(ProcessModel model)
        {
            if (State.ProcessModels.ContainsKey(model.Name))
            {
                State.ProcessModels[model.Name] = model;
            }
            SyncData();
        }

        public void UpdateProcess(string intialKey, ProcessModel newModel)
        {
            if (!string.Equals(intialKey, newModel.Name))
            {
                State.ProcessModels.Remove(intialKey);
            }
            State.ProcessModels[newModel.Name] = newModel;
            SyncData();
        }


        public void AddExecutable(string name, string path)
        {
            State.Executables.Add(new(name, path));
            SyncData();
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
