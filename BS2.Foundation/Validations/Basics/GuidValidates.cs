using System;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(Guid value, Guid expected)
        {
            var success = value == expected;
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(Guid value, Guid unexpected)
        {
            var success = value != unexpected;
            return Compute(success, value);
        }

        public BasicValidates IsEmpty(Guid value)
        {
            var success = value == Guid.Empty;
            return Compute(success, value);
        }

        public BasicValidates IsNotEmpty(Guid value)
        {
            var success = value != Guid.Empty;
            return Compute(success, value);
        }
    }
}