using System.Linq;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates
    {
        public BasicValidates IsOneOf<T>(T value, T[] validValues)
        {
            var success = value != null && validValues.Contains(value);
            return Compute(success, value);
        }
    }
}