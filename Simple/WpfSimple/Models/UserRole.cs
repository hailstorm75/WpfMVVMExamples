namespace WpfSimple.Models
{
  /// <summary>
  /// Data holder for a user role
  /// </summary>
  /// <remarks>
  /// Can be a class or struct
  /// </remarks>
  public readonly struct UserRole
    : IHasId
  {
    #region Properties

    /// <inheritdoc />
    public int Id { get; }
    /// <summary>
    /// Name of the user role
    /// </summary>
    public string Name { get; }

    #endregion

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="id">Id of the given role</param>
    /// <param name="name">Name of the given role</param>
    public UserRole(int id, string name)
    {
      Id = id;
      Name = name;
    }
  }
}
