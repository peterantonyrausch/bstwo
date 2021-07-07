using System.ComponentModel.DataAnnotations;
using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Members
{
    public partial class MemberValidates : Validates
    {
        private MemberValidates Compute(bool success, object value, string message, params string[] memberNames)
        {
            if (!success)
            {
                AddValidation(message, memberNames);
            }

            AddOrReplaceValue(value, memberNames);

            return this;
        }

        private void AddValidation(string message, params string[] memberNames)
        {
            Validations.Add(new ValidationResult(message, memberNames));
        }

        private void AddOrReplaceValue(object value, params string[] memberNames)
        {
            foreach (var memberName in memberNames)
            {
                Values.Remove(memberName);
                Values.Add(memberName, value);
            }
        }

        public T ValueOf<T>(string memberName)
        {
            return (T)Values.GetOrDefault(memberName);
        }

        public Validates Guard()
        {
            if (Error)
            {
                throw new BS2.Foundation.Validations.ValidationException(Validations);
            }

            return this;
        }
    }
}