// Attribute should be "registered" by adding as module or assembly custom attribute
using System.Reflection;
using System;
using MethodDecorator.Fody.Interfaces;

[module: Interceptor]

// Any attribute which provides OnEntry/OnExit/OnException with proper args
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
public class InterceptorAttribute : Attribute, IMethodDecorator
{
    // instance, method and args can be captured here and stored in attribute instance fields
    // for future usage in OnEntry/OnExit/OnException
    MethodBase _method;
    public void Init(object instance, MethodBase method, object[] args)
    {
        _method = method;
        Console.WriteLine(string.Format("Init: {0} [{1}]", _method.DeclaringType.FullName + "." + _method.Name, args.Length));
    }

    public void OnEntry()
    {
        Console.WriteLine($"{_method.DeclaringType.FullName} OnEntry");
    }

    public void OnExit()
    {
        Console.WriteLine($"{_method.DeclaringType.FullName} OnExit");
    }

    public void OnException(Exception exception)
    {
        Console.WriteLine(string.Format("OnException: {0}: {1}", exception.GetType(), exception.Message));
    }
}