using System.ComponentModel.DataAnnotations;
using BS2.Foundation.Extensions;

namespace BS2.Foundation.Validations.Basics
{
    public partial class BasicValidates : Validates
    {
        private const string MemberName = "VALUE";

        public T Value<T>()
        {
            return (T)Values.GetOrDefault(MemberName);
        }

        public void ThrowOnError(string message)
        {
            if (Error)
            {
                new BS2.Foundation.Validations.ValidationException(message);
            }
        }

        private BasicValidates Compute(bool success, object value)
        {
            if (!success)
            {
                AddValidation(value);
            }

            AddOrReplaceValue(value);

            return this;
        }

        private void AddValidation(object value)
        {
            Validations.Add(new ValidationResult($"Valor inválido: {value}."));
        }

        private void AddOrReplaceValue(object value)
        {
            Values.Remove(MemberName);
            Values.Add(MemberName, value);
        }
    }
}