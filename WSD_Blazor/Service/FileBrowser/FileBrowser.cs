namespace WSD_Blazor.Service.FileBrowser
{

    //TODO Courts Idea Kill switch to stop apps

    public static class FileBrowser
    {
        public static string? OpenFilePathToString()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }
        public static string? OpenFilePathToString(string path)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = path;
           
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return path;
        }
    }
}
