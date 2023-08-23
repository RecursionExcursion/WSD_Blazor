using System.Reflection;
using WSD_Blazor.Data;
using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Repository
{
    public class DataManager
    {
        private static readonly Serializer serializer = Serializer.Instance;

        private static readonly Lazy<DataManager> lazyInstance = new Lazy<DataManager>(() => new DataManager());

        public static DataManager Instance => lazyInstance.Value;

        public Dictionary<string, ProcessModel> ProcessModels { get; set; } = serializer.LoadData() ?? new();

        private DataManager() { }

        public void AddNewProcess(ProcessModel model)
        {
            if (ProcessModels.TryAdd(model.Name, model))
            {
                SyncData();
            }
        }

        public ProcessModel GetProcessByName(string name) => ProcessModels[name];

        public void RemoveProcess(ProcessModel model)
        {
            if (model != null)
            {
                ProcessModels.Remove(model.Name);
                SyncData();
            }
        }

        public void UpdateProcess(ProcessModel model)
        {
            if (ProcessModels.ContainsKey(model.Name))
            {
                ProcessModels[model.Name] = model;
            }
            SyncData();
        }

        public void UpdateProcess(ProcessModel initalModel, ProcessModel newModel)
        {
            if (!string.Equals(initalModel.Name, newModel.Name))
            {
                RemoveProcess(initalModel);
            }
            ProcessModels[newModel.Name] = newModel;
            SyncData();
        }

        public void SyncData() => SaveToFile();

        private void LoadFromFile() => ProcessModels = serializer.LoadData() ?? new Dictionary<string, ProcessModel>();

        private void SaveToFile() => serializer.SaveData(ProcessModels);
    }
}
