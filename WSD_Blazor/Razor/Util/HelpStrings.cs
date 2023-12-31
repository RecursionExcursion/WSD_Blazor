namespace WSD_Blazor.Razor.Util
{
    public class HelpStrings
    {
        public static string MainPage { get; private set; } =
            "Create a new process or deploy one that has already been created.";


        public static string ProcessCreationPage { get; private set; } =
          "Add deployment processes to the list below. " +
           "URLs are self-explanatory. " +
           "For Exes, an Executable will be required and can be created under the 'Manage Executables' button. " +
           "An Execuable will contain the file path to the application to be opened. " +
           "Args should include any necessary arguments such as a file path that you would like the program being opened to access.";
    }
}
