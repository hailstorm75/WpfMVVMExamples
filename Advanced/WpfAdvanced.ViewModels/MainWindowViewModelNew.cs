using WpfAdvanced.Interfaces.ViewModels;
using WpfAdvanced.MVVM;

namespace WpfAdvanced.ViewModels
{
  public class MainWindowViewModelNew
    : BasePropertyChanged, IMainWindowViewModel
  {
    /// <inheritdoc />
    public string Title => "Main Window New";
  }
}