using System;
using System.Reflection;

namespace BS2.Foundation.Extensions
{
    internal static class ExceptionExtensions
    {
        public static Exception Unwrap(this TargetInvocationException exception)
        {
            Exception result = exception;
            while (result is TargetInvocationException)
            {
                result = result.InnerException;
            }

            return result;
        }
    }
}