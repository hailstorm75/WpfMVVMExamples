using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using Whathecode.System.Reflection.Extensions;
using WpfAdvanced.Helpers;
using WpfAdvanced.Interfaces.MVVM;
using ReflectionHelper = Whathecode.System.Reflection.ReflectionHelper;

namespace WpfAdvanced.Base
{
  [Serializable]
  [AttributeUsage(AttributeTargets.Constructor)]
  [MulticastAttributeUsage(MulticastTargets.InstanceConstructor, AllowMultiple = false)]
  public class SetViewModel
    : MethodLevelAspect, IInstanceScopedAspect
  {
    #region Fields

    private Type m_viewModelType;
    [NonSerialized]
    private Action<object> m_initializer;
    [NonSerialized]
    private bool m_isInitialized;

    #endregion

    public SetViewModel(Type viewModelType = null)
      => m_viewModelType = viewModelType;

    [OnMethodEntryAdvice, MethodPointcut(nameof(SelectConstructors))]
    public void OnConstructorEntry(MethodExecutionArgs args)
    {
      if (!m_isInitialized)
        m_isInitialized = true;
      m_initializer(args.Instance);
    }

    private IEnumerable<MethodBase> SelectConstructors(MethodBase target)
    {
      // A constructor always has a declaring type.
      Contract.Assume(target.DeclaringType != null);

      return
        // Constructors.
        target.DeclaringType.GetConstructors(ReflectionHelper.InstanceMembers)
        // Deserialization method.
        .Concat<MethodBase>(target.DeclaringType.GetMethods(ReflectionHelper.InstanceMembers).Where(m => m.GetAttributes<OnDeserializingAttribute>().Any()));
    }

    public override void RuntimeInitialize(MethodBase methodInfo)
    {
      // A constructor always has a declaring type.
      Contract.Assume(methodInfo.DeclaringType != null);

      var lookingFor = typeof(IView<IViewModel>);
      var viewModelInterface = methodInfo.DeclaringType.GetInterfaces()
        .FirstOrDefault(type => type.Namespace?.Equals(lookingFor.Namespace, StringComparison.InvariantCulture) == true
                                && type.Name.Equals(lookingFor.Name)
                                && type.GenericTypeArguments.Length == 1);
      if (viewModelInterface is null && m_viewModelType is null)
        throw new NotSupportedException($"Either supply a {nameof(IViewModel)} type in the constructor of the attribute or add the {nameof(IView<IViewModel>)} interface with the respective view model type as the generic parameter.");

      base.RuntimeInitialize(methodInfo);

      var declaringType = methodInfo.DeclaringType;
      var dataContext = declaringType.GetProperty(nameof(FrameworkElement.DataContext));
      var interfaceContext = declaringType.GetProperty("ViewModel");

      if (m_viewModelType is null)
        m_viewModelType = viewModelInterface?.GenericTypeArguments.First();

      var viewModel = new object[] {ViewModelResolver.Resolve(m_viewModelType)};

      m_initializer = instance =>
      {
        dataContext?.SetMethod?.Invoke(instance, viewModel);
        interfaceContext?.SetMethod?.Invoke(instance, viewModel);
      };
    }

    public object CreateInstance(AdviceArgs adviceArgs)
      => MemberwiseClone();

    public void RuntimeInitializeInstance()
      => m_isInitialized = false;
  }
}