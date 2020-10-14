using System.Collections.Generic;

namespace WpfSimple.DataProviders
{
  public static class DataRepository
  {
    public static IEnumerable<(int id, string name)> GetUserRoles()
    {
      yield return (0, "Admin");
      yield return (1, "Manager");
      yield return (2, "User");
      yield return (3, "Guest");
    }
  }
}
