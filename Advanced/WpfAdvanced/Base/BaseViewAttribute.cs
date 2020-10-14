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

    private readonly Type m_viewModelType;
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

      base.RuntimeInitialize(methodInfo);

      var declaringType = methodInfo.DeclaringType;
      var property = declaringType.GetProperty(nameof(FrameworkElement.DataContext));
      m_initializer = instance => property?.SetMethod?.Invoke(instance, new object[] { ViewModelResolver.Resolve(m_viewModelType) });
    }

    public object CreateInstance(AdviceArgs adviceArgs)
      => MemberwiseClone();

    public void RuntimeInitializeInstance()
      => m_isInitialized = false;
  }
}