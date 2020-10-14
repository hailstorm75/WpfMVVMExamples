using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAdvanced.MVVM
{
  /// <summary>
  /// Base for classes that will interact with the View
  /// </summary>
  public abstract class BasePropertyChanged
    : INotifyPropertyChanged
  {
    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Notify the View of changes to a given <paramref name="property"/> value
    /// </summary>
    /// <param name="property">
    /// Name of property
    /// </param>
    /// <example>
    /// Use the nameof keyword instead of typing the <paramref name="property"/> name by hand:
    /// <code>OnPropertyChanged(nameof(MyProperty)</code>
    /// <para/>
    /// or leave empty to use the <see cref="CallerMemberNameAttribute"/>
    /// </example>
    protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
      => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
  }
}
