using Autofac;
using WpfAdvanced.Helpers;
using WpfAdvanced.Interfaces.ViewModels;
using WpfAdvanced.ViewModels;

namespace WpfAdvanced
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    public App()
    {
      var builder = new ContainerBuilder();
      //builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
      builder.RegisterType<MainWindowViewModelNew>().As<IMainWindowViewModel>();

      ViewModelResolver.Initialize(builder);
    }
  }
}
