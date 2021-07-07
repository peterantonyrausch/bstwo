using System.Reflection;

namespace BS2.Foundation.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsVirtual(this PropertyInfo property)
        {
            var methodInfo = property.GetGetMethod(true) ?? property.GetSetMethod(true);
            return !methodInfo.IsNonVirtual();
        }
    }
}