using System;
using System.Reflection;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsSameReferenceAs<T>(T value, T expected, string message, params string[] memberNames)
        {
            var success = ReferenceEquals(value, expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotSameReferenceAs<T>(T value, T unexpected, string message, params string[] memberNames)
        {
            var success = !ReferenceEquals(value, unexpected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsOfType<T>(T value, Type expectedType, string message, params string[] memberNames)
        {
            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            var valueType = value.GetType();
            if (expectedType.GetTypeInfo().IsGenericTypeDefinition && valueType.GetTypeInfo().IsGenericType)
            {
                var genericTypeSuccess = valueType.GetGenericTypeDefinition() == expectedType;
                return Compute(genericTypeSuccess, value, message, memberNames);
            }

            var valueTypeSuccess = valueType == expectedType;
            return Compute(valueTypeSuccess, value, message, memberNames);
        }

        public MemberValidates IsNotOfType<T>(T value, Type unexpectedType, string message, params string[] memberNames)
        {
            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            var valueType = value.GetType();
            if (unexpectedType.GetTypeInfo().IsGenericTypeDefinition && valueType.GetTypeInfo().IsGenericType)
            {
                var genericTypeSuccess = valueType.GetGenericTypeDefinition() != unexpectedType;
                return Compute(genericTypeSuccess, value, message, memberNames);
            }

            var valueTypeSuccess = valueType != unexpectedType;
            return Compute(valueTypeSuccess, value, message, memberNames);
        }

        public MemberValidates IsInstanceOf<T>(T value, Type expectedType, string message, params string[] memberNames)
        {
            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            var success = expectedType.IsInstanceOfType(value);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotInstanceOf<T>(T value, Type unexpectedType, string message, params string[] memberNames)
        {
            if (value is null)
            {
                return Compute(false, value, message, memberNames);
            }

            var success = !unexpectedType.IsInstanceOfType(value);
            return Compute(success, value, message, memberNames);
        }
    }
}