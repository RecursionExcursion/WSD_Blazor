using Microsoft.AspNetCore.Components;
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
    }
}
