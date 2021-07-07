using System;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(Guid value, Guid expected, string message, params string[] memberNames)
        {
            var success = value == expected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(Guid value, Guid unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsEmpty(Guid value, string message, params string[] memberNames)
        {
            var success = value == Guid.Empty;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEmpty(Guid value, string message, params string[] memberNames)
        {
            var success = value != Guid.Empty;
            return Compute(success, value, message, memberNames);
        }
    }
}