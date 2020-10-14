namespace WpfSimple.Models
{
  /// <summary>
  /// Interface fpr types that have an ID
  /// </summary>
  public interface IHasId
  {
    /// <summary>
    /// Id of given instance
    /// </summary>
    int Id { get; }
  }
}