namespace WpfAdvanced.Interfaces.MVVM
{
  /// <summary>
  /// Interface for classes that will represent the view
  /// </summary>
  /// <typeparam name="TViewModel">Specific view model type</typeparam>
  public interface IView<out TViewModel>
    where TViewModel : IViewModel
  {
    /// <summary>
    /// Specific view model of the view
    /// </summary>
    TViewModel ViewModel { get; }
  }
}