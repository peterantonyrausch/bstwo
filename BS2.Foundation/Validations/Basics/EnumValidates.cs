using System;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(Enum value, Enum expected)
        {
            var success = value.GetType() == expected.GetType() && Equals(value, expected);
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(Enum value, Enum unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates HasFlag(Enum value, Enum expectedFlag)
        {
            var success = value != null && value.GetType() == expectedFlag.GetType() && value.HasFlag(expectedFlag);
            return Compute(success, value);
        }

        public BasicValidates HasNotFlag(Enum value, Enum unexpectedFlag)
        {
            var success = value != null && value.GetType() == unexpectedFlag.GetType() && !value.HasFlag(unexpectedFlag);
            return Compute(success, value);
        }
    }
}