using System;
using System.Windows;
using WpfAdvanced.Helpers;
using WpfAdvanced.Interfaces.MVVM;

namespace WpfAdvanced.Base
{
  /// <summary>
  /// Base class for <see cref="Window"/> views
  /// </summary>
  public abstract class BaseWindowView
    : Window, IView<IViewModel>
  {
    /// <inheritdoc />
    public IViewModel ViewModel { get; }

    public BaseWindowView(Type type)
    {
      //ViewModel = ViewModelResolver.Resolve(type);
      //DataContext = ViewModel;
    }
  }
}
