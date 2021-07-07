using System.Linq;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates HasValue<T>(T? value) where T : struct
        {
            var success = value.HasValue;
            return Compute(success, value);
        }

        public BasicValidates HasNotValue<T>(T? value) where T : struct
        {
            var success = !value.HasValue;
            return Compute(success, value);
        }

        public BasicValidates IsNull<T>(T? value) where T : struct
        {
            var success = !value.HasValue;
            return Compute(success, value);
        }

        public BasicValidates IsNotNull<T>(T? value) where T : struct
        {
            var success = value.HasValue;
            return Compute(success, value);
        }

        public BasicValidates HasValue<T>(T value)
        {
            var success = value != null;
            return Compute(success, value);
        }

        public BasicValidates HasNotValue<T>(T value)
        {
            var success = value == null;
            return Compute(success, value);
        }

        public BasicValidates IsNull<T>(T value)
        {
            var success = value == null;
            return Compute(success, value);
        }

        public BasicValidates IsNotNull<T>(T value)
        {
            var success = value != null;
            return Compute(success, value);
        }

        public BasicValidates AllHasValue(decimal?[] values)
        {
            var success = values.All(v => v.HasValue);
            return Compute(success, values);
        }

        public BasicValidates NoneHasValue(decimal?[] values)
        {
            var success = values.All(v => !v.HasValue);
            return Compute(success, values);
        }

        public BasicValidates AnyHasValue(decimal?[] values)
        {
            var success = values.Any(v => v.HasValue);
            return Compute(success, values);
        }
    }
}