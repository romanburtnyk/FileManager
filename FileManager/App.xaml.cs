using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using CompositionService = WpfUtils.CompositionService;

namespace FileManager.ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            CompositionService.Configure(() =>
            {
                var aggregCatalog = new AggregateCatalog();
                var dirCatalog = new DirectoryCatalog(".");
                var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                aggregCatalog.Catalogs.Add(dirCatalog);
                aggregCatalog.Catalogs.Add(assemblyCatalog);
                var container = new CompositionContainer(aggregCatalog);
                return container;
            });
#if TRACE
            //LogManager.Configure(() => new TraceLogger());
#elif DEBUG
            //LogManager.Configure(() => new DebugLogger());
#endif

        }
    }
}
