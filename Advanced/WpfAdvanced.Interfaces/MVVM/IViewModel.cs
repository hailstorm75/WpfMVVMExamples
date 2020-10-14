using System.ComponentModel;

namespace WpfAdvanced.Interfaces.MVVM
{
  /// <summary>
  /// Base interface for view models consumed by <see cref="IView{TViewModel}"/>
  /// </summary>
  public interface IViewModel
    : INotifyPropertyChanged
  {
  }
}