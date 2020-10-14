using System.Windows;
using WpfAdvanced.Base;
using WpfAdvanced.Interfaces.ViewModels;

namespace WpfAdvanced
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
    : Window
  {
    [SetViewModel(typeof(IMainWindowViewModel))]
    public MainWindow()
      => InitializeComponent();
  }
}
