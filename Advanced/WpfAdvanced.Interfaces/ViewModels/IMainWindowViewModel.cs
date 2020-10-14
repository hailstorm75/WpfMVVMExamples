using WpfAdvanced.Interfaces.MVVM;

namespace WpfAdvanced.Interfaces.ViewModels
{
  public interface IMainWindowViewModel
    : IViewModel
  {
    string Title { get; }
  }
}