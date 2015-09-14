using System.Windows;
using Modeling.View;
using Spring.Context.Support;

namespace Modeling
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var ctx = ContextRegistry.GetContext();
            var model = ctx.GetObject("MainViewModel");
            var view = new Main {DataContext = model};
            view.Show();
        }
    }
}
