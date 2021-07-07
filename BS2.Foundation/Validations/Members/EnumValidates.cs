using System;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsEquals(Enum value, Enum expected, string message, params string[] memberNames)
        {
            var success = value.GetType() == expected.GetType() && Equals(value, expected);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates IsNotEquals(Enum value, Enum unexpected, string message, params string[] memberNames)
        {
            var success = value != unexpected;
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasFlag(Enum value, Enum expectedFlag, string message, params string[] memberNames)
        {
            var success = value != null && value.GetType() == expectedFlag.GetType() && value.HasFlag(expectedFlag);
            return Compute(success, value, message, memberNames);
        }

        public MemberValidates HasNotFlag(Enum value, Enum unexpectedFlag, string message, params string[] memberNames)
        {
            var success = value != null && value.GetType() == unexpectedFlag.GetType() && !value.HasFlag(unexpectedFlag);
            return Compute(success, value, message, memberNames);
        }
    }
}