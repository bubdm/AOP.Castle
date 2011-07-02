using System.Reflection;
using System;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace AOP.Castle
{
    public class MethodBoundaryInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                methodInfo = invocation.Method;
            }

            List<MethodBoundaryAttribute> attributes = GetAttributes(methodInfo);

            if (attributes.Count == 0)
            {
                invocation.Proceed();
            }
            else
            {
                InvokeEntry(attributes);
                try
                {
                    invocation.Proceed();
                    InvokeSuccess(attributes);
                }
                catch (Exception err)
                {
                    InvokeException(attributes, err);
                    throw;
                }
                finally
                {
                    InvokeExit(attributes);
                }
            }
        }

        private List<MethodBoundaryAttribute> GetAttributes(MethodInfo methodInfo)
        {
            List<MethodBoundaryAttribute> attributes = new List<MethodBoundaryAttribute>();

            //Method level attributes
            MethodBoundaryAttribute[] methodAttributes = (MethodBoundaryAttribute[])methodInfo.GetCustomAttributes(typeof(MethodBoundaryAttribute), false);

            //Class level attributes
            MethodBoundaryAttribute[] classAttributes = (MethodBoundaryAttribute[])methodInfo.ReflectedType.GetCustomAttributes(typeof(MethodBoundaryAttribute), false);

            //add method level
            attributes.AddRange(methodAttributes);

            //add class attribute if not exist in method
            foreach (MethodBoundaryAttribute classAttr in classAttributes)
            {
                bool exist = false;
                foreach (MethodBoundaryAttribute methodAttr in methodAttributes)
                {
                    if (classAttr.TypeId == methodAttr.TypeId)
                        exist = true;
                }
                if (!exist)
                    attributes.Add(classAttr);
            }

            return attributes;
        }

        private void InvokeEntry(List<MethodBoundaryAttribute> attributes)
        {
            foreach (MethodBoundaryAttribute attr in attributes)
            {
                attr.OnEntry();
            }
        }

        private void InvokeException(List<MethodBoundaryAttribute> attributes, Exception exp)
        {
            foreach (MethodBoundaryAttribute attr in attributes)
            {
                attr.OnException(exp);
            }
        }

        private void InvokeExit(List<MethodBoundaryAttribute> attributes)
        {
            foreach (MethodBoundaryAttribute attr in attributes)
            {
                attr.OnExit();
            }
        }

        private void InvokeSuccess(List<MethodBoundaryAttribute> attributes)
        {
            foreach (MethodBoundaryAttribute attr in attributes)
            {
                attr.OnSuccess();
            }
        }
    }
}
