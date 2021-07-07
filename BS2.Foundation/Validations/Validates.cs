using System.Collections.Generic;
using System.Linq;
using BS2.Foundation.Validations.Basics;
using BS2.Foundation.Validations.Members;

namespace BS2.Foundation.Validations
{
    public class Validates
    {
        public readonly IList<ValidationResult> Validations;
        protected readonly IDictionary<string, object> Values;
        protected bool Error => Validations.Count > 0;
        protected bool Success => !Error;

        protected Validates()
        {
            Validations = new List<ValidationResult>();
            Values = new Dictionary<string, object>();
        }

        public static MemberValidates ThatMembers() => new MemberValidates();

        public static BasicValidates That() => new BasicValidates();

        public static implicit operator bool(Validates validates) => validates.Success;

        public static implicit operator List<ValidationResult>(Validates validates) => validates.Validations.ToList();
    }
}