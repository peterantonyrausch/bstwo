using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BS2.Foundation.Validations
{
    [Serializable]
    public class ValidationException : Exception
    {
        public IList<ValidationResult> ValidationErrors { get; }

        public ValidationException()
        {
            ValidationErrors = new List<ValidationResult>();
        }

        public ValidationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            ValidationErrors = new List<ValidationResult>();
        }

        public ValidationException(string message)
            : base(message)
        {
            ValidationErrors = new List<ValidationResult>();
        }

        public ValidationException(IList<ValidationResult> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationException(string message, IList<ValidationResult> validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
            ValidationErrors = new List<ValidationResult>();
        }
    }
}