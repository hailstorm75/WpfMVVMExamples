using System.Collections.Generic;

namespace WpfSimple.DataProviders
{
  /// <summary>
  /// Provider of data
  /// </summary>
  public static class DataRepository
  {
    /// <summary>
    /// Simulates retrieving data from some source - be it a database or file
    /// </summary>
    /// <returns>Data</returns>
    public static IEnumerable<(int id, string name)> GetUserRoles()
    {
      yield return (0, "Admin");
      yield return (1, "Manager");
      yield return (2, "User");
      yield return (3, "Guest");
    }
  }
}
