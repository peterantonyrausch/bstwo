using System;
using System.Reflection;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsSameReferenceAs<T>(T value, T expected)
        {
            var success = ReferenceEquals(value, expected);
            return Compute(success, value);
        }

        public BasicValidates IsNotSameReferenceAs<T>(T value, T unexpected)
        {
            var success = !ReferenceEquals(value, unexpected);
            return Compute(success, value);
        }

        public BasicValidates IsOfType<T>(T value, Type expectedType)
        {
            if (value is null)
            {
                return Compute(false, value);
            }

            var valueType = value.GetType();
            if (expectedType.GetTypeInfo().IsGenericTypeDefinition && valueType.GetTypeInfo().IsGenericType)
            {
                var genericTypeSuccess = valueType.GetGenericTypeDefinition() == expectedType;
                return Compute(genericTypeSuccess, value);
            }

            var valueTypeSuccess = valueType == expectedType;
            return Compute(valueTypeSuccess, value);
        }

        public BasicValidates IsNotOfType<T>(T value, Type unexpectedType)
        {
            if (value is null)
            {
                return Compute(false, value);
            }

            var valueType = value.GetType();
            if (unexpectedType.GetTypeInfo().IsGenericTypeDefinition && valueType.GetTypeInfo().IsGenericType)
            {
                var genericTypeSuccess = valueType.GetGenericTypeDefinition() != unexpectedType;
                return Compute(genericTypeSuccess, value);
            }

            var valueTypeSuccess = valueType != unexpectedType;
            return Compute(valueTypeSuccess, value);
        }

        public BasicValidates IsInstanceOf<T>(T value, Type expectedType)
        {
            if (value is null)
            {
                return Compute(false, value);
            }

            var success = expectedType.IsInstanceOfType(value);
            return Compute(success, value);
        }

        public BasicValidates IsNotInstanceOf<T>(T value, Type unexpectedType)
        {
            if (value is null)
            {
                return Compute(false, value);
            }

            var success = !unexpectedType.IsInstanceOfType(value);
            return Compute(success, value);
        }
    }
}