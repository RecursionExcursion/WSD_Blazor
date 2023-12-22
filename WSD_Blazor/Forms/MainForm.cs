using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WSD_Blazor.Razor.Routing;

namespace WSD_Blazor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();


            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();

            var blazorWebView = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = @"wwwroot\index.html",
                Services = services.BuildServiceProvider()
            };

            blazorWebView.RootComponents.Add<AppRouter>("#app");
            this.Controls.Add(blazorWebView);
        }

        private void InitializeForm()
        {
            this.Width = 1000;
            this.Height = 750;
        }

        private void DisableWindowResizing()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
