using System.Linq;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates HasValue<T>(T? value, string message, params string[] memberNames) where T : struct
        {
            var success = value.HasValue;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasNotValue<T>(T? value, string message, params string[] memberNames) where T : struct
        {
            var success = !value.HasValue;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNull<T>(T? value, string message, params string[] memberNames) where T : struct
        {
            var success = !value.HasValue;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNull<T>(T? value, string message, params string[] memberNames) where T : struct
        {
            var success = value.HasValue;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasValue<T>(T value, string message, params string[] memberNames)
        {
            var success = value != null;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasNotValue<T>(T value, string message, params string[] memberNames)
        {
            var success = value == null;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNull<T>(T value, string message, params string[] memberNames)
        {
            var success = value == null;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNull<T>(T value, string message, params string[] memberNames)
        {
            var success = value != null;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates AllHasValue(decimal?[] values, string message, params string[] memberNames)
        {
            var success = values.All(v => v.HasValue);
            return Compute(success, values, message, memberNames);
        }

        public MemberValidates NoneHasValue(decimal?[] values, string message, params string[] memberNames)
        {
            var success = values.All(v => !v.HasValue);
            return Compute(success, values, message, memberNames);
        }

        public MemberValidates AnyHasValue(decimal?[] values, string message, params string[] memberNames)
        {
            var success = values.Any(v => v.HasValue);
            return Compute(success, values, message, memberNames);
        }
    }
}