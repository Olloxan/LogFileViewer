using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogFileViewer
{
    internal class AppBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _Container = new SimpleContainer();

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var viewModelAssemblies = new[]
            {
                Assembly.GetExecutingAssembly(),
            };
            var notLoaded = viewModelAssemblies.Where(r => !loadedAssemblies.Any(l => l.FullName == r.FullName));
            foreach (var nl in notLoaded)
                Assembly.Load(nl.FullName);

            var retViewModelAssemblies = AppDomain.CurrentDomain.GetAssemblies().
                Where(a => a.ManifestModule.Name.StartsWith("LogFileViewer")).ToList();
            return retViewModelAssemblies;
        }

        protected override void Configure()
        {
            _Container.Singleton<IWindowManager, WindowManager>();
            _Container.Singleton<IEventAggregator, EventAggregator>();
            _Container.PerRequest<IMain, MainViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _Container.GetInstance(serviceType, key);

        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _Container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _Container.BuildUp(instance);
        }


        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<IMain>();
        }
    }
}
