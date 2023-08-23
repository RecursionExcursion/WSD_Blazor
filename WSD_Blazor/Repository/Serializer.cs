using System.Text.Json;
using WSD_Blazor.Service.Deployer;

namespace WSD_Blazor.Data
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    /* Methods must not be static, Folders must be initalized first*/
    public class Serializer
    {
        private static readonly string UserDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string DocumentFolder = "VSFoofInc";
        private static readonly string SubFolder = "ModelApp";
        private static readonly string FileName = "model.json";

        private static readonly Lazy<Serializer> lazyInstance = new Lazy<Serializer>(() => new Serializer());
        public static Serializer Instance => lazyInstance.Value;

        private Serializer()
        {
            InitializeFolders();
        }

        private void InitializeFolders()
        {
            //Creates Folder structure if it does not exist
            CreateFilePathIfAbsent();

            //Creates Json file if it does not already exist
            if (File.Exists(GetFilePath()) == false)
            {
                Dictionary<string, ProcessModel> emptyUsers = new();
                SaveData(emptyUsers);
            }
        }

        public void SaveData(Dictionary<string, ProcessModel> users)
        {
            var json = JsonSerializer.Serialize(users);

            File.WriteAllText(GetFilePath(), json);
        }

        public Dictionary<string, ProcessModel>? LoadData()
        {

            string[] lines = File.ReadAllLines(GetFilePath());

            string usersJson = string.Join(Environment.NewLine, lines);
            Dictionary<string, ProcessModel>? userProfiles = JsonSerializer.Deserialize<Dictionary<string, ProcessModel>>(usersJson);
            return userProfiles;
        }

        private static void CreateFilePathIfAbsent() => Directory.CreateDirectory(GetFolderPath());

        private static string GetFolderPath() => Path.Combine(UserDocuments, DocumentFolder, SubFolder);

        private static string GetFilePath() => Path.Combine(GetFolderPath(), FileName);
    }
}