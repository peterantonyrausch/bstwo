using System;
using System.Collections.Generic;

namespace BS2.Foundation.Validations
{
    public class ValidationResult
    {
        public IEnumerable<string> MemberNames { get; }

        public string ErrorMessage { get; set; }

        public ValidationResult(string errorMessage) : this(errorMessage, null)
        {
        }

        public ValidationResult(string errorMessage, params string[] memberNames)
        {
            ErrorMessage = errorMessage;
            MemberNames = memberNames ?? Array.Empty<string>();
        }

        protected ValidationResult(ValidationResult validationResult)
        {
            if (validationResult == null)
            {
                throw new ArgumentNullException(nameof(validationResult));
            }

            ErrorMessage = validationResult.ErrorMessage;
            MemberNames = validationResult.MemberNames;
        }

        public override string ToString() => ErrorMessage ?? base.ToString();
    }
}