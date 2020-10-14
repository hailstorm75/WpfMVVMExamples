using System.Windows;
using WpfAdvanced.Base;
using WpfAdvanced.Interfaces.MVVM;
using WpfAdvanced.Interfaces.ViewModels;

namespace WpfAdvanced
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
    : Window, IView<IMainWindowViewModel>
  {
    [SetViewModel]
    public MainWindow()
      => InitializeComponent();

    /// <inheritdoc />
    public IMainWindowViewModel ViewModel { get; private set; }
  }
}
