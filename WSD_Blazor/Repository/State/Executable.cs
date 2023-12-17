namespace WSD_Blazor.Repository.State
{
    public class Executable
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Executable(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public Executable()
        {
            Name = "";
            Path = "";
        }
    }
}
