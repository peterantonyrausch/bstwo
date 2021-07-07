using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsEquals(object value, object expected)
        {
            var success = value.IsSameOrEqualTo(expected);
            return Compute(success, value);
        }

        public BasicValidates IsNotEquals(object value, object unexpected)
        {
            var success = !value.IsSameOrEqualTo(unexpected);
            return Compute(success, value);
        }

        public BasicValidates HasSameType(object value, object expected)
        {
            var success = value.GetType() == expected.GetType();
            return Compute(success, value);
        }

        public BasicValidates HasNotSameType(object value, object unexpected)
        {
            var success = value.GetType() != unexpected.GetType();
            return Compute(success, value);
        }

        public BasicValidates IsNullReference(object value)
        {
            var success = value is null;
            return Compute(success, value);
        }

        public BasicValidates IsNotNullReference(object value)
        {
            var success = value is object;
            return Compute(success, value);
        }

        public BasicValidates IsSameReferenceAs(object value, object expected)
        {
            var success = ReferenceEquals(value, expected);
            return Compute(success, value);
        }

        public BasicValidates IsNotSameReferenceAs(object value, object unexpected)
        {
            var success = !ReferenceEquals(value, unexpected);
            return Compute(success, value);
        }
    }
}