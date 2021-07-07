using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(object value, object expected, string message, params string[] memberNames)
        {
            var success = value.IsSameOrEqualTo(expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(object value, object unexpected, string message, params string[] memberNames)
        {
            var success = !value.IsSameOrEqualTo(unexpected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasSameType(object value, object expected, string message, params string[] memberNames)
        {
            var success = value.GetType() == expected.GetType();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasNotSameType(object value, object unexpected, string message, params string[] memberNames)
        {
            var success = value.GetType() != unexpected.GetType();
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNullReference(object value, string message, params string[] memberNames)
        {
            var success = value is null;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotNullReference(object value, string message, params string[] memberNames)
        {
            var success = value is object;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsSameReferenceAs(object value, object expected, string message, params string[] memberNames)
        {
            var success = ReferenceEquals(value, expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotSameReferenceAs(object value, object unexpected, string message, params string[] memberNames)
        {
            var success = !ReferenceEquals(value, unexpected);
            return Compute(success, value, message, memberNames);
        }
    }
}