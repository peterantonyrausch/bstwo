using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BS2.Foundation.Extensions
{
    /// <summary>
    ///     Extension methods for getting method and property selectors for a type.
    /// </summary>
    [DebuggerNonUserCode]
    public static class TypeExtensions
    {
        private const BindingFlags PublicMembersFlag =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        private const BindingFlags AllMembersFlag =
            PublicMembersFlag | BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        ///     Determines whether the specified method has been annotated with a specific attribute.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the specified method has attribute; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this MemberInfo method)
            where TAttribute : Attribute
        {
            return method.GetCustomAttributes(typeof(TAttribute), true).Any();
        }

        public static bool HasMatchingAttribute<TAttribute>(this MemberInfo type,
            Expression<Func<TAttribute, bool>> isMatchingAttributePredicate)
            where TAttribute : Attribute
        {
            var isMatchingAttribute = isMatchingAttributePredicate.Compile();

            return GetCustomAttributes<TAttribute>(type).Any(isMatchingAttribute);
        }

        public static bool HasMatchingAttribute<TAttribute>(this Type type,
            Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, bool inherit = false)
            where TAttribute : Attribute
        {
            var isMatchingAttribute = isMatchingAttributePredicate.Compile();

            return GetCustomAttributes<TAttribute>(type, inherit).Any(isMatchingAttribute);
        }

        public static bool IsDecoratedWith<TAttribute>(this MemberInfo type)
            where TAttribute : Attribute
        {
            return GetCustomAttributes<TAttribute>(type).Any();
        }

        public static bool IsDecoratedWith<TAttribute>(this Type type, bool inherit = false)
            where TAttribute : Attribute
        {
            return GetCustomAttributes<TAttribute>(type, inherit).Any();
        }

        private static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(MemberInfo type)
            where TAttribute : Attribute
        {
            return type.GetCustomAttributes(false).OfType<TAttribute>();
        }

        private static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(Type type, bool inherit = false)
            where TAttribute : Attribute
        {
            return GetCustomAttributes<TAttribute>(type.GetTypeInfo(), inherit);
        }

        private static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(TypeInfo typeInfo, bool inherit = false)
            where TAttribute : Attribute
        {
            return typeInfo.GetCustomAttributes(inherit).OfType<TAttribute>();
        }

        public static bool IsSameOrInherits(this Type actualType, Type expectedType)
        {
            return actualType == expectedType ||
                   expectedType.IsAssignableFrom(actualType);
        }

        /// <summary>
        ///     NOTE: This method does not give the expected results with open generics
        /// </summary>
        public static bool Implements(this Type type, Type expectedBaseType)
        {
            return
                expectedBaseType.IsAssignableFrom(type)
                && type != expectedBaseType;
        }

        internal static Type[] GetClosedGenericInterfaces(Type type, Type openGenericType)
        {
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == openGenericType)
            {
                return new[] { type };
            }

            var interfaces = type.GetInterfaces();
            return
                interfaces
                    .Where(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == openGenericType)
                    .ToArray();
        }

        public static bool OverridesEquals(this Type type)
        {
#if NETSTANDARD1_3
            MethodInfo[] methods = type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);

            return methods.Any(m => m.Name == "Equals"
                && m.GetParameters().SingleOrDefault()?.ParameterType == typeof(object)
                && m.GetBaseDefinition().DeclaringType != m.DeclaringType);
#else
            var method = type.GetTypeInfo()
                .GetMethod("Equals", new[] { typeof(object) });

            return method != null
                   && method.GetBaseDefinition().DeclaringType != method.DeclaringType;
#endif
        }

        /// <summary>
        ///     Finds the property by a case-sensitive name.
        /// </summary>
        /// <returns>
        ///     Returns <c>null</c> if no such property exists.
        /// </returns>
        public static PropertyInfo FindProperty(this Type type, string propertyName, Type preferredType)
        {
            var properties =
                type.GetProperties(PublicMembersFlag)
                    .Where(pi => pi.Name == propertyName)
                    .ToList();

            return properties.Count > 1
                ? properties.SingleOrDefault(p => p.PropertyType == preferredType)
                : properties.SingleOrDefault();
        }

        /// <summary>
        ///     Finds the field by a case-sensitive name.
        /// </summary>
        /// <returns>
        ///     Returns <c>null</c> if no such property exists.
        /// </returns>
        public static FieldInfo FindField(this Type type, string fieldName, Type preferredType)
        {
            var properties =
                type.GetFields(PublicMembersFlag)
                    .Where(pi => pi.Name == fieldName)
                    .ToList();

            return properties.Count > 1
                ? properties.SingleOrDefault(p => p.FieldType == preferredType)
                : properties.SingleOrDefault();
        }

        public static IEnumerable<PropertyInfo> GetNonPrivateProperties(this Type typeToReflect,
            IEnumerable<string> filter = null)
        {
            var query =
                from propertyInfo in GetPropertiesFromHierarchy(typeToReflect)
                where HasNonPrivateGetter(propertyInfo)
                where !propertyInfo.IsIndexer()
                where filter == null || filter.Contains(propertyInfo.Name)
                select propertyInfo;

            return query.ToArray();
        }

        public static IEnumerable<FieldInfo> GetNonPrivateFields(this Type typeToReflect)
        {
            var query =
                from fieldInfo in GetFieldsFromHierarchy(typeToReflect)
                where !fieldInfo.IsPrivate
                where !fieldInfo.IsFamily
                select fieldInfo;

            return query.ToArray();
        }

        private static IEnumerable<FieldInfo> GetFieldsFromHierarchy(Type typeToReflect)
        {
            return GetMembersFromHierarchy(typeToReflect, GetPublicFields);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesFromHierarchy(Type typeToReflect)
        {
            return GetMembersFromHierarchy(typeToReflect, GetPublicProperties);
        }

        private static IEnumerable<TMemberInfo> GetMembersFromHierarchy<TMemberInfo>(
            Type typeToReflect,
            Func<Type, IEnumerable<TMemberInfo>> getMembers)
            where TMemberInfo : MemberInfo
        {
            if (IsInterface(typeToReflect))
            {
                var propertyInfos = new List<TMemberInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(typeToReflect);
                queue.Enqueue(typeToReflect);

                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in GetInterfaces(subType))
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = getMembers(subType);

                    var newPropertyInfos = typeProperties.Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return getMembers(typeToReflect);
        }

        private static bool IsInterface(Type typeToReflect)
        {
            return typeToReflect.GetTypeInfo().IsInterface;
        }

        private static Type[] GetInterfaces(Type type)
        {
            return type.GetInterfaces();
        }

        private static PropertyInfo[] GetPublicProperties(Type type)
        {
            return type.GetProperties(PublicMembersFlag);
        }

        private static FieldInfo[] GetPublicFields(Type type)
        {
            return type.GetFields(PublicMembersFlag);
        }

        private static bool HasNonPrivateGetter(PropertyInfo propertyInfo)
        {
            var getMethod = propertyInfo.GetGetMethod(true);
            return getMethod != null && !getMethod.IsPrivate && !getMethod.IsFamily;
        }

        /// <summary>
        ///     Check if the type is declared as abstract.
        /// </summary>
        /// <param name="type">Type to be checked</param>
        /// <returns></returns>
        public static bool IsCSharpAbstract(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsAbstract && !typeInfo.IsSealed;
        }

        /// <summary>
        ///     Check if the type is declared as sealed.
        /// </summary>
        /// <param name="type">Type to be checked</param>
        /// <returns></returns>
        public static bool IsCSharpSealed(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsSealed && !typeInfo.IsAbstract;
        }

        /// <summary>
        ///     Check if the type is declared as static.
        /// </summary>
        /// <param name="type">Type to be checked</param>
        /// <returns></returns>
        public static bool IsCSharpStatic(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsSealed && typeInfo.IsAbstract;
        }

        public static MethodInfo GetMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
        {
            return type.GetMethods(AllMembersFlag)
                .SingleOrDefault(m =>
                    m.Name == methodName &&
                    m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));
        }

        public static bool HasMethod(this Type type, string methodName, IEnumerable<Type> parameterTypes)
        {
            return type.GetMethod(methodName, parameterTypes) != null;
        }

        public static MethodInfo GetParameterlessMethod(this Type type, string methodName)
        {
            return type.GetMethod(methodName, Enumerable.Empty<Type>());
        }

        public static bool HasParameterlessMethod(this Type type, string methodName)
        {
            return type.GetParameterlessMethod(methodName) != null;
        }

        public static PropertyInfo GetPropertyByName(this Type type, string propertyName)
        {
            return type.GetProperty(propertyName, AllMembersFlag);
        }

        public static bool HasExplicitlyImplementedProperty(this Type type, Type interfaceType, string propertyName)
        {
            var hasGetter =
                type.HasParameterlessMethod(string.Format("{0}.get_{1}", interfaceType.FullName, propertyName));
            var hasSetter = type.GetMethods(AllMembersFlag)
                                .SingleOrDefault(m =>
                                    m.Name == string.Format("{0}.set_{1}", interfaceType.FullName, propertyName) &&
                                    m.GetParameters().Length == 1) != null;

            return hasGetter || hasSetter;
        }

        public static PropertyInfo GetIndexerByParameterTypes(this Type type, IEnumerable<Type> parameterTypes)
        {
            return type.GetProperties(AllMembersFlag)
                .SingleOrDefault(p =>
                    p.IsIndexer() && p.GetIndexParameters().Select(i => i.ParameterType).SequenceEqual(parameterTypes));
        }

        public static bool IsIndexer(this PropertyInfo member)
        {
            return member.GetIndexParameters().Length != 0;
        }

        public static ConstructorInfo GetConstructor(this Type type, IEnumerable<Type> parameterTypes)
        {
            return type
                .GetConstructors(PublicMembersFlag)
                .SingleOrDefault(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));
        }

        public static MethodInfo GetImplicitConversionOperator(this Type type, Type sourceType, Type targetType)
        {
            return type
                .GetConversionOperators(sourceType, targetType, name => name == "op_Implicit")
                .SingleOrDefault();
        }

        public static MethodInfo GetExplicitConversionOperator(this Type type, Type sourceType, Type targetType)
        {
            return type
                .GetConversionOperators(sourceType, targetType, name => name == "op_Explicit")
                .SingleOrDefault();
        }

        private static IEnumerable<MethodInfo> GetConversionOperators(this Type type, Type sourceType, Type targetType,
            Func<string, bool> predicate)
        {
            return type
                .GetMethods()
                .Where(m =>
                    m.IsPublic
                    && m.IsStatic
                    && m.IsSpecialName
                    && m.ReturnType == targetType
                    && predicate(m.Name)
                    && m.GetParameters().Length == 1
                    && m.GetParameters()[0].ParameterType == sourceType);
        }

        public static bool HasValueSemantics(this Type type)
        {
            return type.OverridesEquals() &&
                   !type.IsAnonymousType() && !type.IsTuple() && !IsKeyValuePair(type);
        }

        private static bool IsKeyValuePair(Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }

        private static bool IsAnonymousType(this Type type)
        {
            var nameContainsAnonymousType = type.FullName.Contains("AnonymousType");

            if (!nameContainsAnonymousType)
            {
                return false;
            }

            var hasCompilerGeneratedAttribute =
                type.GetTypeInfo().GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any();

            return hasCompilerGeneratedAttribute;
        }

        private static bool IsTuple(this Type type)
        {
            if (!type.GetTypeInfo().IsGenericType)
            {
                return false;
            }

            var openType = type.GetGenericTypeDefinition();
            return openType == typeof(ValueTuple<>)
                   || openType == typeof(ValueTuple<,>)
                   || openType == typeof(ValueTuple<,,>)
                   || openType == typeof(ValueTuple<,,,>)
                   || openType == typeof(ValueTuple<,,,,>)
                   || openType == typeof(ValueTuple<,,,,,>)
                   || openType == typeof(ValueTuple<,,,,,,>)
                   || openType == typeof(ValueTuple<,,,,,,,>) && type.GetGenericArguments()[7].IsTuple();
        }
    }
}