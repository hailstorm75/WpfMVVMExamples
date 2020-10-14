using System.Collections.ObjectModel;
using System.Linq;
using WpfSimple.DataProviders;
using WpfSimple.Helpers;
using WpfSimple.Models;

namespace WpfSimple.ViewModels
{
  /// <summary>
  /// View model for the main window
  /// </summary>
  public sealed class MainWindowViewModel
    : BasePropertyChanged
  {
    #region Fields

    private string m_roleId;
    private UserRole m_selectedRole;

    #endregion

    #region Properties

    public ObservableCollection<UserRole> Roles { get; }

    public UserRole SelectedRole
    {
      get => m_selectedRole;
      set
      {
        m_selectedRole = value;

        RoleId = value.Id.ToString();
      }
    }

    public string RoleId
    {
      get => m_roleId;
      set
      {
        m_roleId = value;
        OnPropertyChanged();
      }
    }

    #endregion

    /// <summary>
    /// Default constructor
    /// </summary>
    public MainWindowViewModel()
      => Roles = new ObservableCollection<UserRole>(DataRepository.GetUserRoles().Select(data => new UserRole(data.id, data.name)));
  }
}
