using System;
using System.Reflection;
using Castle.Core.Interceptor;

namespace AOP.Castle
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class MethodBoundaryAttribute : Attribute
    {
        public virtual void OnEntry(MethodExecutionArgs args) { }
        public virtual void OnSuccess(MethodExecutionArgs args) { }
        public virtual void OnExit(MethodExecutionArgs args) { }
        public virtual void OnException(MethodExecutionArgs args) { }
    }
}
