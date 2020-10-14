using System;
using Autofac;
using WpfAdvanced.Interfaces.MVVM;

namespace WpfAdvanced.Helpers
{
  public static class ViewModelResolver
  {
    #region Fields

    private static bool m_isInitialized;
    private static IContainer m_container;

    #endregion

    public static void Initialize(ContainerBuilder builder)
    {
      if (m_isInitialized)
        throw new NotSupportedException("Resolver was initialized before");

      m_container = builder.Build();
      m_isInitialized = true;
    }

    public static IViewModel Resolve(Type type)
    {
      if (!m_isInitialized)
        throw new NotSupportedException("Resolver was not initialized");

      using var scope = m_container.BeginLifetimeScope();
      return (IViewModel)scope.Resolve(type);
    }

    public static TViewModel Resolve<TViewModel>()
      where TViewModel : IViewModel
    {
      if (!m_isInitialized)
        throw new NotSupportedException("Resolver was not initialized");

      using var scope = m_container.BeginLifetimeScope();
      return scope.Resolve<TViewModel>();
    }
  }
}
