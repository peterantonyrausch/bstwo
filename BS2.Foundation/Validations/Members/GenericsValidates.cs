using System.Linq;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates
    {
        public MemberValidates IsOneOf<T>(T value, T[] validValues, string message, params string[] memberNames)
        {
            var success = value != null && validValues.Contains(value);
            return Compute(success, value, message, memberNames);
        }
    }
}