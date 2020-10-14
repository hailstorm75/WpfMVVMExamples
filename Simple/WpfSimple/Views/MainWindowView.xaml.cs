using System.Windows;
using WpfSimple.ViewModels;

namespace WpfSimple.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindowView
    : Window
  {
    public MainWindowView()
    {
      // Set the view data context to the corresponding view before initialization
      // Doing to after will prevent the ViewModel from catching View load events
      DataContext = new MainWindowViewModel();

      InitializeComponent();
    }
  }
}
