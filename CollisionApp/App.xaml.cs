using Autofac;
using CollisionApp.ViewModels;
using CollisionApp.Views;
using CollisionServices.Implementations;
using CollisionServices.Interfaces;
using System.Windows;

namespace CollisionApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            
            var builder = new ContainerBuilder();

            // Register types                        
            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<CubeCollisionViewModel>();
            builder.RegisterType<CubeCollisionControl>();
            builder.RegisterType<CubeCollisionService>().As<ICubeCollisionService>();            

            container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.DataContext = container.Resolve<CubeCollisionViewModel>();
                mainWindow.Show();
            }
        }
    }
}
