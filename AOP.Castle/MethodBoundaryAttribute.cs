using System;
using System.Reflection;
using Castle.Core.Interceptor;

namespace AOP.Castle
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class MethodBoundaryAttribute : Attribute
    {
        public virtual void OnEntry() { }
        public virtual void OnSuccess() { }
        public virtual void OnExit() { }
        public virtual void OnException(Exception exception) { }
    }
}
