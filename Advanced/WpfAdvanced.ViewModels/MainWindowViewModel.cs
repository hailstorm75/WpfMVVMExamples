using WpfAdvanced.Interfaces.ViewModels;
using WpfAdvanced.MVVM;

namespace WpfAdvanced.ViewModels
{
  public class MainWindowViewModel
    : BasePropertyChanged, IMainWindowViewModel
  {
    /// <inheritdoc />
    public string Title => "Main Window";
  }
}
